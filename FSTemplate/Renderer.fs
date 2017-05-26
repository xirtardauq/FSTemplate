module Renderer

open System.Reflection
open FSTemplate

let matchParams (methodInfo: MethodInfo) (viewContext: ViewContext) = 
    let parameters = methodInfo.GetParameters() |> Array.map (fun x -> x.ParameterType) |> List.ofSeq
    let modelType = viewContext.model.GetType()
    let viewContextType = typedefof<ViewContext>

    match parameters with    
    | x::y when x = modelType && y.Length = 1 && y.[0] = viewContextType -> 
        [| viewContext.model; (viewContext :> obj) |]
    | x::y when x = viewContextType && y.Length = 1 && y.[0] = modelType -> 
        [|(viewContext :> obj); viewContext.model;|] 
    | [x] when x = modelType -> [|viewContext.model|]
    | [x] when x = viewContextType -> [|viewContext|]
    | _ -> [||]

