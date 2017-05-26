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

    // marker attribute
    type Render() =
        inherit Attribute()

