namespace FSTemplate

open Microsoft.FSharp.Compiler.SourceCodeServices
open System.Reflection
open System
open System.IO
open System.Collections.Generic

type FSTemplateRenderer() = 
    member this.Render(path: string, viewContext: ViewContext) = 
        let checker = FSharpChecker.Create()
        //let assembly = @"C:\Users\Andrii Pastushenko\Desktop\projects\FSTemplate\FSTemplate\bin\Debug\FSTemplate.dll"
        let codeBase = Assembly.GetExecutingAssembly().CodeBase
        let uri = new UriBuilder(codeBase)
        let assembly = Uri.UnescapeDataString(uri.Path)        

        let options = 
            [| "fsc.exe"; 
               "-o"; "dummy.dll"; 
               "-a"; path;               
            |]

        let errors, exitCode, dynAssembly = 
            checker.CompileToDynamicAssembly(options, execute=None)
            |> Async.RunSynchronously

        if exitCode = 1 then 
            failwith (errors |> Array.map (fun x -> x.Message) |> String.concat "; ")

        let assemblyCode = dynAssembly.Value
        
        let declaredMethods = 
            assemblyCode.DefinedTypes
            |> List.ofSeq
            |> List.map (fun x -> x.DeclaredMethods |> List.ofSeq) 
            |> List.concat

        let withAttributes =
            declaredMethods
            |> List.map (fun x -> x, x.GetCustomAttributes() |> Seq.map (fun x -> x.GetType()))             

        let render = 
            withAttributes
            |> List.filter (fun (_, y) -> Seq.contains typedefof<Html.Render> y)
            |> List.head
            |> fst
        
        let parameters = Renderer.matchParams render viewContext

        let res = render.Invoke(null, parameters) :?> Element.Node

        Element.render res

