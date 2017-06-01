$output = ".\bld\"

function BuildNuget($projectPath) {
    nuget pack $projectPath -Prop Configuration=Release -Build -OutputDirectory $output
}

function Clean() {
    if(!(Test-Path $output)) {
        return
    }

    Write-Output "Cleaning build folder"
    Remove-Item ($output + "*")
}

function PublishNuget($name) {
    nuget push $name -Source https://www.nuget.org/api/v2/package
}

function Build() {
    Clean
    BuildNuget(".\src\FSTemplate\FSTemplate.fsproj")
    BuildNuget(".\src\FSTemplate.Mvc\FSTemplate.Mvc.csproj")
}

switch ($args[0]) {
    "build" { 
        Build
    }
    "publish" {        
        if(!(Test-Path $output)) {
            Build
        }

        Get-ChildItem $output | ForEach-Object {
            PublishNuget $_.FullName
        }
    }
    Default {
        Write-Error "Unknown or missing build parameter. Use ""build"" or ""publish"""
    }
}
