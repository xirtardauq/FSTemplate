module RendererTests

open NUnit.Framework
open FSTemplate
open System.Reflection
open FsUnit

module CreateCompilerOptions =
    open FsUnit

    [<Test>]
    let ``createCompilerOptions should build options correctly``() =
        let path = "some/path"
        let res = Renderer.createCompilerOptions path

        res |> should equal [| 
                "fsc.exe"; 
                "-o"; "dummy.dll";
                "-a"; path 
            |]

module HandleCompileResults = 
    [<Test>]
    let ``handleCompileResults should return success with compiled assembly when exit code is 0``() =
        let assembly = Assembly.GetCallingAssembly()
        match Renderer.handleCompileResults ([], 0, Some assembly) with
        | Success s -> s |> should equal assembly
        | Error e -> failwithf "Unexpected Error %A" e

    [<Test>]
    let ``handleCompileResults should return error with concatenated error messages when exit code is not 0``() =
        match Renderer.handleCompileResults (["some error"; "some other error"], 1, None) with
        | Success s -> 
            failwithf "Unexpected Success %A" s
        | Error e -> 
            e |> should equal "One or more errors occured during template compilation: \nsome error\nsome other error"


