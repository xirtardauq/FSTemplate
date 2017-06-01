namespace FSTemplate

open System.Text.RegularExpressions

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
        let pathList = [
                ("{controller}", context.controller);
                ("{view}", context.viewName)
            ]    

        pathList
        |> List.map (fun (x, y) -> new Regex(x), y)
        |> List.fold (fun state (x, y) -> x.Replace(state, y)) path
    