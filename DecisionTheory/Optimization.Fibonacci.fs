module Optimization.Fibonacci

open System
open System.Collections.Generic

let methodName = "Метод Фибоначчи"

let fibCache = Dictionary<int, float>()

let rec fib n = 
    if fibCache.ContainsKey(n)
    then 
        fibCache.[n]
    else 
        let c = 
            match n with
            | 0 -> 0.
            | 1 -> 1.
            | n -> (fib (n - 1)) + (fib (n - 2))
        fibCache.[n] <- c
        c

/// Возвращает оптимальное количество итераций, которые нужно совершить по методу фибоначчи,
/// чтобы достичь заданной точности поиска минимума на заданном отрезке.
let optn (a, b) (accuracy: float) : int =
    int (abs (b - a) / accuracy)

let rec argmin (a, b) (n: int) func =
    if n = 0
    then
        a
    else
        let x1 = a + (fib (n + 0) / fib (n + 2)) * (b - a)
        let x2 = a + (fib (n + 1) / fib (n + 2)) * (b - a)
        let y1 = func x1
        let y2 = func x2
        if y1 < y2
        then argmin (a, x2) (n - 1) func
        else argmin (x1, b) (n - 1) func
