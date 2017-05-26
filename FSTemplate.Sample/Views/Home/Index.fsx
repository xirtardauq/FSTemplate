#load "../references.fsx"
open FSTemplate.Html

[<Render>]
let render() = 
    ul [] 
        ([0..3] |> List.map (fun x -> li [] [text (string x)]))
