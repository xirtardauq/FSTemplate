namespace FSTemplate

open System.IO
open Util

type FSTemplateRenderer(useCache) = 
    let compileTemplate = 
        passSecond Renderer.compileTemplate >>
        bind (passSecond Renderer.getDeclaredMethods) >>
        bind (passSecond Renderer.findRenderMethod)
        
    let trySetCache cacheKey value = 
        match value with
        | Success(methodInfo, _) -> TemplateCache.setCache cacheKey methodInfo
        | Error e -> ()

    let tryGetCache fileInfo = 
        if useCache then
            TemplateCache.tryGetFromCache fileInfo
        else 
            None

    member this.Render(fileInfo: FileInfo, viewContext: ViewContext) =      
        let compiledTemplate = 
            match tryGetCache fileInfo with
            | Some template -> 
                Success(template, viewContext)
            | None -> 
                let template = compileTemplate(fileInfo.FullName, viewContext)
                trySetCache fileInfo template
                template

        compiledTemplate
        |> bind Renderer.matchParams
        |> bind Renderer.renderTemplate

    member this.ResultOrThrow(res) =
        match res with 
        | Success s -> s
        | Error e -> failwith e

