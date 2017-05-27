module Base

type RenderResult<'a> = 
    | Success of 'a
    | Error of string

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
