module Optimization.GoldenSection

open System

/// Константа, определяющая отношение золтого сечения.
let private goldenSection = 0.5 * (1.0 + sqrt 5.0)
let private Ф = goldenSection

let rec argmin func accuracy (a, b) = 
    if b - a < accuracy then 
        0.5 * (a + b)
    else 
        let t = (b - a) / Ф
        let x1 = b - t
        let x2 = a + t
        let y1 = func x1
        let y2 = func x2
        match y1 >= y2 with
        | true  -> argmin func accuracy (x1, b)
        | false -> argmin func accuracy (a, x2)