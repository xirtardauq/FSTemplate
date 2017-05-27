namespace FSTemplate

open Base

type FSTemplateRenderer() = 
    let renderWrapper = 
        passSecond Renderer.compileTemplate >>
        bind (passSecond Renderer.getDeclaredMethods) >>
        bind (passSecond Renderer.findRenderMethod) >>
        bind Renderer.matchParams >>
        bind Renderer.renderTemplate

    member this.Render(path: string, viewContext: ViewContext) = 
        renderWrapper(path, viewContext)

    member this.ResultOrThrow(res) =
        match res with 
        | Success s -> s
        | Error e -> failwith e

