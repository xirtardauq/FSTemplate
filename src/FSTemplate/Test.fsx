#load "Scripts/load-references-debug.fsx"
#load "Scripts/load-project-debug.fsx"

open Element
open FSTemplate.Html 
open FSTemplate

let tree = 
    ul [] 
        ([0..3] |> List.map (fun x -> li [] [text (string x)]))

render tree