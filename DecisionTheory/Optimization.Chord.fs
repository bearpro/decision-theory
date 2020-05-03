module Optimization.Chord

let methodName = "Метод Хорд"

let rec argmin (a, b) accuracy primeFunc =
    let x = a - ((primeFunc a) / ((primeFunc a) - (primeFunc b))) * (a - b)
    let y = primeFunc x
    match abs(y) < accuracy with
    | true  -> x
    | false ->
        let range = if y > 0.0 then (a, x) else (x, b)
        argmin range accuracy primeFunc
