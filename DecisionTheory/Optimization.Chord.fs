module Optimization.Chord

let methodName = "Метод Хорд"

let rec argmin (a, b) accuracy primeFunc =
    let x = a - ((primeFunc a) / ((primeFunc a) - (primeFunc b))) * (a - b)
    let y = primeFunc x
    if abs(y) < accuracy
    then x
    else
        if y > 0.0
        then argmin (a, x) accuracy primeFunc
        else argmin (x, b) accuracy primeFunc
