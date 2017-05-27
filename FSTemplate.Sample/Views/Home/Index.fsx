#load "../references.fsx"
open FSTemplate.Html
open FSTemplate
open FSTemplate.Sample.Models

let transformValuesToLi values = 
    values 
    |> Array.map (fun x -> li [] [text (string x)])
    |> List.ofArray

[<Render>]
let index (model: IndexModel) = 
    model.Name
    
