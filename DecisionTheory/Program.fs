// Learn more about F# at http://fsharp.org

open System
open Optimization
open Functions

let range = (-5., 5.)
let x = "x"
let funcExamples = [
    Add(Mul(Val(2.0), Mul(Var(x), Var(x))), Mul(Val(6.0), Var(x)))
    Add(Mul(Val 5.0, Mul(Var x, Var x)), Var x)
]

[<EntryPoint>]
let main argv =
    let f = funcExamples.[0]
    let fp = diff f x
    let fpp = diff fp x

    printfn "%-30s %f" GoldenSection.methodName (GoldenSection.argmin 0.001 range (call f))
    printfn "%-30s %f" Fibonacci.methodName     (Fibonacci.argmin range (Fibonacci.optn range 0.1) (call f))
    printfn "%-30s %f" Dichotomy.methodName     (Dichotomy.argmin range 0.001 0.01 (call f))
    printfn "%-30s %f" Enumeration.methodName   (Enumeration.argmin range 0.01 (call f))
    printfn "%-30s %f" BitwiseSearch.methodName (BitwiseSearch.argmin range 2.0 0.25 0.01 (call f))
    printfn "%-30s %f" Newton.methodName        (Newton.argmin -5.0 0.01 (call fpp) (call fp))
    printfn "%-30s %f" Chord.methodName         (Chord.argmin (-5.0, 5.0) 0.01 (call fp))
    printfn "%-30s %f" Midpoint.methodName      (Midpoint.argmin (-5.0, 5.0) 0.01 (call fp))

    0
