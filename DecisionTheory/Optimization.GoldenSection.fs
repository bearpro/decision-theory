module Optimization.GoldenSection

open System

/// Константа, определяющая отношение золтого сечения.
let private goldenSection = float ((sqrt (5.0) + 1.0) / 2.0)
let private Ф = goldenSection

let rec argmin (func: float -> float) (accuracy: float) (a, b) =
    let x1 = b - ((b - a) / Ф)
    let x2 = a + ((b - a) / Ф)
    let y1 = func x1
    let y2 = func x2
    let range =  
        if y1 >= y2
        then (x1, b)
        else (a, x2)
    let rangeSize = 
        (fun (a, b) -> abs (b - a)) range
    if rangeSize < accuracy
    then (a + b) / 2.
    else argmin func accuracy range
