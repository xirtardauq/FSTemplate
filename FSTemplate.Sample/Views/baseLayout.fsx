#load "references.fsx"
open FSTemplate.Html
open FSTemplate

let baseLayout body = 
    html 
        [stylesheet "Content/Site.css"] 
        (body @ [script "Scripts/Site.js"])