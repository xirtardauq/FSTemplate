module Element

type Attr = 
    Attr of string * string

type Tag = {
    tag: string
    attr: Attr list
    children: Node list
}
and Node = Tag of Tag | Text of string

let renderAttr attrs = 
    attrs
    |> List.map (fun (Attr(x, y)) -> " " + x + "=\"" + y + "\"")
    |> String.concat ""

let element tag attr children = 
    Tag({tag=tag; attr=attr; children=children})

let attr name value = 
    Attr(name, value)

let rec render (node: Node) =
    match node with
    | Tag(elem) ->
        "<" + elem.tag + renderAttr elem.attr + ">" +
        (List.map render elem.children |> String.concat " ") +
        "</" + elem.tag + ">"
    | Text(text) -> text



