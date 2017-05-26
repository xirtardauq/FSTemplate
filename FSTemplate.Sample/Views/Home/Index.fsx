#load "../references.fsx"
open FSTemplate.Html
open FSTemplate
open FSTemplate.Sample.Models

let transformValuesToLi values = 
    values 
    |> Array.map (fun x -> li [] [text (string x)])
    |> List.ofArray

[<Render>]
let render (model: IndexModel) (viewContext: ViewContext)= 
    p [] [
        text model.Name
        ul [] (model.Values |> transformValuesToLi)
    ]
    
