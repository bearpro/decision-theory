module Optimization.Fibonacci

open System

let rec fib n = 
    match n with
    | 0 -> 0.
    | 1 -> 1.
    | n -> (fib (n - 1)) + (fib (n - 2))

let rec argmin func (a, b) (n: int) =
    let rec rArgmin func (a, b) (x1, x2) n =
        if n = 0
        then x1
        else
            let y1 = func x1
            let y2 = func x2
            if y1 > y2
            then rArgmin func (x1, b) (x2, b - (x1 - a)) (n - 1)
            else rArgmin func (a, x2) (a + (b - x2), x1) (n - 1)

    let x1 = a + (fib (n + 0) / fib (n + 2)) * (b - a)
    let x2 = a + (fib (n + 1) / fib (n + 2)) * (b - a)
    rArgmin func (a, b) (x1, x2) n
