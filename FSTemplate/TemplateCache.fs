module TemplateCache

open System.IO
open System.Collections.Concurrent
open System.Reflection
open FSTemplate.Config
open FSTemplate

type DefaultCacheProvider() =
    let cache = new ConcurrentDictionary<string, MethodInfo*int64>()
    
    interface ICacheProvider with
        member x.TryGet(arg1: string): bool*(MethodInfo*int64) = 
            cache.TryGetValue arg1
        member x.TrySet(arg1: string, arg2: MethodInfo*int64): bool = 
            cache.TryAdd(arg1, arg2)  
        member x.TryRemove(cacheKey) =
            let result: MethodInfo*int64 = null, 0L
            cache.TryRemove(cacheKey, ref result)

let getTime (fileInfo: FileInfo) = 
    fileInfo.LastWriteTime.ToFileTimeUtc()

let tryGetFromCache (fileInfo: FileInfo) =    
    let prov = ConfigStore.GetInstance().CacheProvider 
    let mutable result = null, 0L
    let time = getTime fileInfo

    match prov.TryGet(fileInfo.FullName) with
    | true, result ->
        if snd result = time then
            Some (fst result)
        else
            while not (prov.TryRemove(fileInfo.FullName)) do ()
            None
    | false, _ -> 
        None

let setCache (fileInfo: FileInfo) obj = 
    let prov = ConfigStore.GetInstance().CacheProvider 
    while not (prov.TrySet(fileInfo.FullName, (obj, getTime fileInfo))) do 
        ()
