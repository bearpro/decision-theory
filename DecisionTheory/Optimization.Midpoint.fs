module Optimization.Midpoint

let methodName = "Метод средней точки"

let rec argmin (a, b) accuracy primeFunc =
    let x = (a + b) / 2.0
    let y = primeFunc x
    match abs(y) < accuracy with
    | true  -> (a + b) / 2.0
    | false ->
        let range = if y > 0.0 then (a, x) else (x, b)
        argmin range accuracy primeFunc 