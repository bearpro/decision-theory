module Optimization.Enumeration

let methodName = "Метод перебора"

let rec private segments a b d = seq {
    if a + d < b 
    then
        yield a
        yield! segments (a+d) b d
}

let argmin (a, b) accuracy func =
    segments a b accuracy
    |> Seq.map (fun x -> (x, func x))
    |> Seq.minBy (fun (x, y) -> y)
    |> fun (x, y) -> x + (accuracy / 2.0)