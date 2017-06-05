namespace FSTemplate

open System.IO
open Util

type FSTemplateRenderer(useCache) =
    let compileTemplate = 
        Renderer.createCompilerOptions >> 
        Renderer.callFSharpCompiler >> 
        Renderer.handleCompileResults
 
    let getDeclaredMethods = 
        Renderer.getDeclaredMethods >> 
        errorEmptyList "Compiled template does not contain any methods"

    let getRenderMethod = 
        Renderer.filterRenderMethod >> 
        errorEmptyList "Compiled template does not contain method marked with [<Render>] attribute" >>
        bind (Util.headOrError "Compiled template contains more than 1 Render methods") >>
        bind (fst >> Success)                        

    let compileTemplate = 
        passSecond compileTemplate >>
        bind (passSecond getDeclaredMethods) >>
        bind (passSecond getRenderMethod)

    let matchParams (methodInfo, viewContext) =
        let parameters = Renderer.getMethodParameters methodInfo         
        passSecond (fun () -> Renderer.matchParams parameters viewContext) ((), methodInfo)
        
    let trySetCache cacheKey value = 
        match value with
        | Success(methodInfo, _) -> TemplateCache.setCache cacheKey methodInfo
        | Error _ -> ()

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
        |> bind matchParams
        |> bind Renderer.renderTemplate

    member this.ResultOrThrow(res) =
        match res with 
        | Success s -> s
        | Error e -> failwith e

