module Renderer

open System.Reflection
open FSTemplate
open Microsoft.FSharp.Compiler.SourceCodeServices

let createCompilerOptions path = [| 
        "fsc.exe"; 
        "-o"; "dummy.dll"; // when compiling to dynamic assembly -o parameter is ignored
        "-a"; path 
    |]

let callFSharpCompiler options = 
    let transformFirst f (a, b, c) = 
        (f a), b, c

    let checker = FSharpChecker.Create()
    checker.CompileToDynamicAssembly(options, execute=None)    
    |> Async.RunSynchronously
    |> transformFirst (Array.map (fun x -> x.Message))

let handleCompileResults (errors, exitCode, (dynAssembly: Assembly option)) =     
    match exitCode with 
    | 0 -> Success dynAssembly.Value
    | _ -> Error ("One or more errors occured during template compilation: \n" + 
                 (errors |> String.concat "\n"))

let getDeclaredMethods (assembly: Assembly) =     
    assembly.DefinedTypes        
    |> Seq.map (fun x -> x.DeclaredMethods) 
    |> Seq.concat
    |> List.ofSeq

let filterRenderMethod (declaredMethods: MethodInfo list) = 
    declaredMethods
    |> List.map (fun x -> x, x.GetCustomAttributes() |> Seq.map (fun x -> x.GetType()))             
    |> List.filter (fun (_, y) -> Seq.contains typedefof<Html.Render> y)


let matchParams (methodInfo: MethodInfo, viewContext: ViewContext) = 
    let parameters = 
        methodInfo.GetParameters() 
        |> Array.map (fun x -> x.ParameterType) 
        |> List.ofSeq

    let modelType = if not (viewContext.model = null) then viewContext.model.GetType() else null
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