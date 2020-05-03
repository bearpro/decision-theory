// Learn more about F# at http://fsharp.org

open System
open Optimization
open Functions

let range = (-5., 5.)

type OptymizationAlgorithm =
    { Name: string
      Algorithm: (float -> float) -> float}


let optimizationAlgorythms = 
    [ { Name      = GoldenSection.methodName
        Algorithm = GoldenSection.argmin 0.001 range }
      { Name      = Fibonacci.methodName
        Algorithm = Fibonacci.argmin range (Fibonacci.optimalIterations range 0.1) }
      { Name      = Dichotomy.methodName
        Algorithm = Dichotomy.argmin range 0.001 0.01 }
      { Name      = Enumeration.methodName
        Algorithm = Enumeration.argmin range 0.01 } 
      { Name      = BitwiseSearch.methodName
        Algorithm = BitwiseSearch.argmin range 2.0 0.25 0.01 }]
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
    let z = Newton.argmin -5.0 0.01 (call fpp) (call fp)
    printfn "%A" z
    for { Name = name; Algorithm = argmin } in optimizationAlgorythms do
        printfn "%s: %f" name (argmin (call f))
    printfn "%s: %f" Newton.methodName (Newton.argmin -5.0 0.01 (call fpp) (call fp))
    0
