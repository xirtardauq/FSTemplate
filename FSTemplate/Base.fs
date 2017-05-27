module Base

open System.Reflection

type RenderResult<'a> = 
    | Success of 'a
    | Error of string

type ICacheProvider = 
    abstract member TryGet: string -> bool*(MethodInfo*int64) 
    abstract member TrySet: string * (MethodInfo*int64) -> bool
    abstract member TryRemove: string -> bool

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
