module Element

type Attr = 
    Attr of string * string

type TagInfo = {
    tag: string
    attr: Attr list
    children: Tag list
}
and Tag = 
    | Paired of TagInfo
    | Unpaired of TagInfo    
    | Text of string    

let renderAttr attrs = 
    attrs
    |> List.map (fun (Attr(x, y)) -> x + "=\"" + y + "\"")
    |> String.concat " "

let addLeadingSpace = 
    function
    | null -> null
    | "" -> ""
    | str -> " " + str
    
let rec render =    
    function
    | Paired(elem) ->
        "<" + elem.tag + addLeadingSpace (renderAttr elem.attr) + ">" +
        (elem.children |> List.map render |> String.concat " ") +
        "</" + elem.tag + ">"
    | Unpaired(elem) -> 
        "<" + elem.tag + addLeadingSpace (renderAttr elem.attr) + "/>"
    | Text(text) -> text

let pairedTag tag attr children = 
    Paired({tag=tag; attr=attr; children=children})

let unpairedTag tag attr = 
    Unpaired({tag=tag; attr=attr; children=[]})

let attr name value = 
    Attr(name, value)



