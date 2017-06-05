$output = ".\bld\"
$test = ".\test\"
$testDll = $test + "*\bin\Release\*"
$nunit = ".\packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe"
$openCover = ".\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe"
$reportGenerator = ".\packages\ReportGenerator.2.5.8\tools\ReportGenerator.exe"

function Clean() {
    if(!(Test-Path $output)) {
        return
    }

    Write-Output "Cleaning build folder"
    Remove-Item ($output + "*")
}

function Build() {
    function BuildNuget($projectPath) {
        nuget pack $projectPath -Prop Configuration=Release -Build -OutputDirectory $output
    }

    Clean
    BuildNuget(".\src\FSTemplate\FSTemplate.fsproj")
    BuildNuget(".\src\FSTemplate.Mvc\FSTemplate.Mvc.csproj")
}

function Test() {
    Get-ChildItem $test -Include "*Tests.*proj" -Recurse | ForEach-Object {
        msbuild $_.FullName /p:Configuration=Release
    }

    $testLibs = Get-ChildItem $testDll -Include "*Tests.dll" -Recurse | ForEach-Object { """" +  $_.FullName +  """"}
    $nunitArgs = [String]::Join(" ", $testLibs)
    $coverageOutput = ".\.coverage\coverage.xml"

    if (!(Test-Path ".\.coverage")) {
        mkdir ".\.coverage"
    }

    .$openCover -target:$nunit "-targetargs:""$($nunitArgs)""" -filter:"-*Tests" -output:$coverageOutput -register:user -hideskipped:All

    .$reportGenerator "-reports:$($coverageOutput)" "-targetdir:.\.coverage"
}

function Publish () {
    Get-ChildItem $output | ForEach-Object {
        nuget push $_.FullName -Source https://www.nuget.org/api/v2/package
    }
}

switch ($args[0]) {
    "build" { 
        Build
    }
    "publish" {        
        Publish    
    }
    "test" {
        Test
    }
    Default {
        Build
        Test
        Publish
    }
}
