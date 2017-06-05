module TestUtils
    
let create2Cases cases = 
    [for x in cases do yield [|(fst x) :> obj; (snd x) :> obj|]]

let create3Cases cases = 
    [for (x, y, z) in cases do yield [|x :> obj; y :> obj; z :> obj|]]
