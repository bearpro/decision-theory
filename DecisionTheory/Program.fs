// Learn more about F# at http://fsharp.org

open System
open Optimization

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

[<EntryPoint>]
let main argv =
    let f (x) = 2. * (x ** 2.) + 6. * x
    //let f (x) = 5. * (x ** 2.) + x
    for { Name = name; Algorithm = argmin } in optimizationAlgorythms do
        printfn "%s: %f" name (argmin f)
    0
