// Learn more about F# at http://fsharp.org

open System
open Optimization

[<EntryPoint>]
let main argv =
    let f (x) = 2. * x * x + 6. * x
    let gsArg = GoldenSection.argmin f 0.001 (-5., 5.)
    let fibArg = Fibonacci.argmin f (-5., 5.) 10
    printfn "Минимум по алгоритму золтого сечения:   %f" gsArg
    printfn "Минимум по алгоритму золтого Фибоначчи: %f" fibArg
    0
