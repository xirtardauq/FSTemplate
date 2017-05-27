module Base

type RenderResult<'a> = 
    | Success of 'a
    | Error of string

let bind func = 
    fun input -> 
        match input with 
        | Success s -> func s
        | Error e -> Error e
