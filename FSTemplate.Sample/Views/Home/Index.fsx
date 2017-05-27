#load "../references.fsx"
#load "../baseLayout.fsx"

open FSTemplate.Html
open FSTemplate
open FSTemplate.Sample.Models

let transformValuesToLi values = 
    values 
    |> Array.map (fun x -> li [] [text (string x)])
    |> List.ofArray

[<Render>]
let index (model: IndexModel) = 
    BaseLayout.baseLayout [
        div [] [
            text model.Name; 
            ul [] (model.Values |> transformValuesToLi)
        ]
    ]
    
