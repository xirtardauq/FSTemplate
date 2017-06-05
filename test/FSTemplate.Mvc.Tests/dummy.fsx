#r "bin/Debug/FSTemplate.dll"
#r "bin/Debug/FSTemplate.Mvc.dll"

open FSTemplate.Html

[<Render>]
let someView() =
    div [] [text "Hello World"]