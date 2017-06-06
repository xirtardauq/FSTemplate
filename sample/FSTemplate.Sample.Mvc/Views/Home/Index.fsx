#load "../references.fsx"
#load "../baseLayout.fsx"

open FSTemplate
open FSTemplate.Sample.Mvc.Models

let transformValuesToLi values = 
    values 
    |> Array.map (fun x -> li [] [text (string x)])
    |> List.ofArray

[<Render>]
let index (model: IndexModel) = 
    BaseLayout.baseLayout [
        div [class' "container"] [
            text model.Name; 
            ul [id' "list"] (model.Values |> transformValuesToLi)
        ]
    ]
    
