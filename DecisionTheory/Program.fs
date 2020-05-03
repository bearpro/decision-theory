// Learn more about F# at http://fsharp.org

open System
open Optimization

[<EntryPoint>]
let main argv =
    //let f (x) = 2. * (x ** 2.) + 6. * x
    let f (x) = 5. * (x ** 2.) + x
    let range = (-5., 5.)
    let gsArg = GoldenSection.argmin f 0.001 range
    let fibArg = Fibonacci.argmin f range (Fibonacci.optimalIterations range 0.1)
    let dxArg = Dichotomy.argmin f range 0.001 0.01
    printfn "Минимум по алгоритму золтого сечения:   %f" gsArg
    printfn "Минимум по алгоритму Фибоначчи:         %f" fibArg
    printfn "Минимум по алгоритму дихотомии:         %f" dxArg
    0
