module UtilTests

open NUnit.Framework
open FSTemplate
open FsUnit
open System
    
module Bind = 
    let sut = Util.bind (fun x -> Success (x + 1))

    [<Test>]
    let ``binded function should return Error if error is passed``() =                       
        let error: RenderResult<int> = Error "some error"
        let res = sut error

        res |> should equal error

    [<Test>]
    let ``binded function should return error with same error message``() = 
        let err = "some error"
        let res = sut (Error err)

        match res with 
        | Success _ -> failwith "unexpected success"
        | Error e -> e |> should equal err


    [<Test>]
    let ``binded function should pass success value to arg function``() =
        let success = Success 1
        let res = sut success

        res |> should equal (Success 2)

module PassSecond = 
    [<Test>]
    let ``passSecond should return function that bypasses second tuple argument to success result``() =
        let sut = Util.passSecond (fun x -> Success (x + 1))
        sut (1, 3) |> should equal (Success (2, 3))

    [<Test>]
    let ``passSecond should return function that correctly handles error result``() =
        let sut = Util.passSecond (fun x -> Error x) 
        
        match sut ("2", 3) with
        | Success _ -> failwith "unexpected Success"
        | Error e -> e |> should equal "2"

module MapViewPath = 
    [<Test>]
    let ``mapViewPath should return empty path for input empty path with any args``() = 
        Util.mapViewPath "" {controller="qwe"; viewName="123"} 
        |> should equal ""

    let cases = [
        [|{controller=null; viewName="123"} :> obj; "controller should not be null" :> obj|]
        [|{controller="qwe"; viewName=null} :> obj; "view should not be null" :> obj|]
    ]
    [<TestCaseSource("cases")>]
    let ``mapViewPath should correctly handle null values in context`` param str =         
        (fun () -> Util.mapViewPath "{controller}/{view}" param |> ignore) 
        |> should (throwWithMessage str) typeof<Exception>

    [<Test>]
    let ``mapViewPath should map path according to the template``() =
        Util.mapViewPath "{controller}/{view}" {controller="qwe"; viewName="rty"}
        |> should equal "qwe/rty"

module ErrorEmptyList = 
    [<Test>]
    let ``errorEmptyList should return error on empty list``() =
        let res = Util.errorEmptyList "error" []

        match res with 
        | Error e -> e |> should equal "error"
        | Success _ -> failwith "unexpected success"

    [<Test>]
    let ``errorEmptyList should return Success on non empty list``() =
        let res = Util.errorEmptyList "" [1]

        match res with 
        | Success e -> e |> should equal [1]
        | Error _ -> failwith "unexpected error"

