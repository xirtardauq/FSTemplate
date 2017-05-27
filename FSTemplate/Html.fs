namespace FSTemplate

open System
open Element

module Html =     
    let p = element "p"
    let a = element "a"
    let label = element "label"
    let li = element "li"
    let ul = element "ul"
    let text = Element.Text
    let div = element "div"
    let private body = element "body"
    let private head = element "head"
    
    let html head_ body_ = 
        element "html" [] [head [] head_; body [] body_]

    let stylesheet path = 
        element "link" [Attr("rel", "stylesheet"); Attr("href", path)] []

    let script path = 
        element "script" [Attr("src", path)] []

    // marker attribute
    type Render() =
        inherit Attribute()

