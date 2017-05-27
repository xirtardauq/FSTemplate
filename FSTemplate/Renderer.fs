module Renderer

open System.Reflection
open FSTemplate
open Base
open Microsoft.FSharp.Compiler.SourceCodeServices

let compileTemplate path = 
    let checker = FSharpChecker.Create()    

    let options = 
        [| "fsc.exe"; 
            "-o"; "dummy.dll"; // when compiling to dynamic assembly -o parameter is ignored
            "-a"; path;               
        |]

    let errors, exitCode, dynAssembly = 
        checker.CompileToDynamicAssembly(options, execute=None)
        |> Async.RunSynchronously

    match exitCode with 
    | 0 -> Success dynAssembly.Value
    | _ -> Error ("One or more errors occured during template compilation: \n" + 
                 (errors |> Array.map (fun x -> x.Message) |> String.concat "\n"))

let getDeclaredMethods (assembly: Assembly) = 
    let declaredMethods = 
        assembly.DefinedTypes        
        |> Seq.map (fun x -> x.DeclaredMethods) 
        |> Seq.concat
        |> List.ofSeq

    match declaredMethods.Length with 
    | 0 -> Error "Compiled template does not contain any methods"
    | _ -> Success declaredMethods

let findRenderMethod (declaredMethods: MethodInfo list) = 
    let withAttributes =
        declaredMethods
        |> List.map (fun x -> x, x.GetCustomAttributes() |> Seq.map (fun x -> x.GetType()))             

    let withRender = 
        withAttributes
        |> List.filter (fun (_, y) -> Seq.contains typedefof<Html.Render> y)
    
    match withRender.Length with 
    | 0 -> Error "Compiled template does not contain method marked with [<Render>] attribute"       
    | 1 -> Success (fst withRender.Head)
    | _ -> Error "Compiled template contains more than 1 Render methods"

let matchParams (methodInfo: MethodInfo, viewContext: ViewContext) = 
    let parameters = 
        methodInfo.GetParameters() 
        |> Array.map (fun x -> x.ParameterType) 
        |> List.ofSeq

    let modelType = viewContext.model.GetType()
    let viewContextType = typedefof<ViewContext>

    match parameters with    
    | x::y when x = modelType && y.Length = 1 && y.[0] = viewContextType -> 
        Success (methodInfo, [| viewContext.model; (viewContext :> obj) |])
    | x::y when x = viewContextType && y.Length = 1 && y.[0] = modelType -> 
        Success (methodInfo, [|(viewContext :> obj); viewContext.model;|])
    | [x] when x = modelType -> 
        Success (methodInfo, [|viewContext.model|])
    | [x] when x = viewContextType -> 
        Success (methodInfo, [|viewContext|])
    | [] -> 
        Success (methodInfo, [||])
    | _ -> Error "Unknown render method signature"

let renderTemplate (methodInfo: MethodInfo, parameters) = 
    try
        let res = methodInfo.Invoke(null, parameters) :?> Element.Node
        Success(Element.render res)
    with 
       | :? System.InvalidCastException as e -> 
            Error ("Invalid result type of Render method: " + e.Message)
       | :? System.Reflection.TargetInvocationException as e -> 
            Error ("Exception occured during template execution: " + e.InnerException.Message + "\n" + e.InnerException.StackTrace)
       | e -> 
            Error e.Message