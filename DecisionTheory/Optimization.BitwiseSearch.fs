module Optimization.BitwiseSearch

let methodName = "Метод поразрядного поиска"

let rec private segments a b d = seq {
    if a + d < b 
    then
        yield a
        yield! segments (a+d) b d
}

let private armgminrange (a, b) accuracy func =
    segments a b accuracy
    |> Seq.map (fun x -> (x, func x))
    |> Seq.minBy (fun (x, y) -> y)
    |> fun (x, y) -> x - (accuracy / 2.0), x + (accuracy / 2.0)

let rec argmin range accuracy accuracyTarget accuracyGrouthFactor func =
    let sr = armgminrange range accuracy func
    match accuracy <= accuracyTarget, sr with
    | true, (a, b) -> (a + b) / 2.0
    | false, range -> 
        let accuracy = accuracy * accuracyGrouthFactor
        argmin range accuracy accuracyTarget accuracyGrouthFactor func