namespace FSTemplate

module Util = 
    let bind func = 
        fun input -> 
            match input with 
            | Success s -> func s
            | Error e -> Error e

    let passSecond f =
        fun (x, y) ->
            match f x with
            | Success s -> Success (s, y)
            | Error e -> Error e

    let mapViewPath path (context: ViewResolverContext) =
        let assertValue ((pattern: string, value) as t) = 
            if value = null then
                failwithf "%s should not be null" (pattern.Substring(1, pattern.Length - 2))
            else 
                t

        let pathList = [
                ("{controller}", context.controller);
                ("{view}", context.viewName)
            ]    

        pathList
        |> List.map assertValue
        |> List.fold (fun (state: string) (x, y) -> state.Replace(x, y)) path
    