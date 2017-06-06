module ElementTests

open FsUnit
open NUnit.Framework
open Element
open FSTemplate

module RenderAttr =       
    [<Test>]
    let ``renderAttr should return empty string for empty attribute list``() = 
        renderAttr [] 
        |> should equal ""

    [<Test>]
    let ``renderAttr should correctly render attribute list``() = 
        renderAttr [Attr("test", "value"); Attr("test1", "value1")] 
        |> should equal "test=\"value\" test1=\"value1\""

module AddLeadingSpace =
    [<Test>]
    let ``addLeadingSpace should not add space to an empty string``() =
        addLeadingSpace "" |> should equal ""

    [<Test>]
    let ``addLeadingSpace should add space to string``() =      
        addLeadingSpace "test string" |> should equal " test string"

    [<Test>]
    let ``addLeadingSpace should handle null value``() =      
        addLeadingSpace null |> should equal null

module Render = 
    [<Test>]
    let ``render should return string for Text element``() =
        render (Text "sample") |> should equal "sample"

    [<Test>]
    let ``render should correctly render unpaired tags``() =
        render (unpairedTag "test" []) |> should equal "<test/>"

    [<Test>]
    let ``render should correctly render unpaired tags with attributes``() =
        render (unpairedTag "test" [class' "some"]) |> should equal "<test class=\"some\"/>"

    [<Test>]
    let ``render should correctly render paired tags``() =
        render (pairedTag "test" [] []) |> should equal "<test></test>"

    [<Test>]
    let ``render should correctly render paired tags with attributes``() =
        render (pairedTag "test" [class' "some"] []) |> should equal "<test class=\"some\"></test>"

    [<Test>]
    let ``render should correctly render paired tags with children``() =
        render (pairedTag "test" [] [div [id' "test"] []]) |> should equal "<test><div id=\"test\"></div></test>"

module TagShortcuts = 
    [<Test>]
    let ``pairedTag should return constructed tag with info``() = 
        let children = [div [] []]
        let attr = [class' "class1"]
        let tag = pairedTag "test" attr children

        match tag with
        | Paired info -> 
            info.tag |> should equal "test"
            info.children |> should equal children
            info.attr |> should equal attr
        | _ -> failwith "Unexpected not paired tag" 

    [<Test>]
    let ``unpairedTag should return constructed tag with info``() = 
        let attr = [class' "class1"]
        let tag = unpairedTag "test" attr

        match tag with
        | Unpaired info -> 
            info.tag |> should equal "test"
            info.children |> should equal []
            info.attr |> should equal attr
        | _ -> failwith "Unexpected not unpaired tag"
        
    [<Test>]
    let ``attr should return constructed attribute with info``() = 
        attr "test" "value" |> should equal (Attr("test", "value"))
