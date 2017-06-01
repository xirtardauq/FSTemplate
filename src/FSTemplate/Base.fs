namespace FSTemplate

open System.Reflection
open System.Collections.Generic
open System.IO


type RenderResult<'a> = 
    | Success of 'a
    | Error of string

type ICacheProvider = 
    abstract member TryGet: string -> bool*(MethodInfo*int64) 
    abstract member TrySet: string * (MethodInfo*int64) -> bool
    abstract member TryRemove: string -> bool

type ViewContext = {
    tempData: IDictionary<string, obj>
    viewData: IDictionary<string, obj>
    model: obj
}

type ViewResolverContext = {
    controller: string
    viewName: string
}

type IViewResolver = 
    abstract member Resolve : ViewResolverContext -> string
