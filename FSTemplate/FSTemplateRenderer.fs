namespace FSTemplate

open Base

type FSTemplateRenderer() = 
    let renderWrapper = 
        Renderer.compileTemplate >>
        bind Renderer.getDeclaredMethods >>
        bind Renderer.findRenderMethod >>
        bind Renderer.matchParams >>
        bind Renderer.renderTemplate

    member this.Render(path: string, viewContext: ViewContext) = 
        renderWrapper(path, viewContext)

    member this.ResultOrThrow(res) =
        match res with 
        | Success s -> s
        | Error e -> failwith e

