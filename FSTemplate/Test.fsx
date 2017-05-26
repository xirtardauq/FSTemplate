#load "Scripts/load-references-debug.fsx"
#load "Element.fs"
#load "Html.fs"

open Element
open FSTemplate.Html 

let tree = 
    ul [] 
        ([0..3] |> List.map (fun x -> li [] [text (string x)]))

render tree