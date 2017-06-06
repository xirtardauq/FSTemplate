#r "bin/Release/FSTemplate.dll"
#r "bin/Release/FSTemplate.Mvc.dll"

open FSTemplate

[<Render>]
let someView() =
    div [] [text "Hello World"]