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

let f = funcExamples.[0]
let fp = diff f x
let fpp = diff fp x

let optimizations = [
    fun () -> GoldenSection.methodName, (GoldenSection.argmin 0.001 range (call f))
    fun () -> Fibonacci.methodName, (Fibonacci.argmin range (Fibonacci.optn range 0.1) (call f))
    fun () -> Dichotomy.methodName, (Dichotomy.argmin range 0.001 0.01 (call f))
    fun () -> Enumeration.methodName, (Enumeration.argmin range 0.01 (call f))
    fun () -> BitwiseSearch.methodName, (BitwiseSearch.argmin range 2.0 0.25 0.01 (call f))
    fun () -> Newton.methodName, (Newton.argmin -5.0 0.01 (call fpp) (call fp))
    fun () -> Chord.methodName, (Chord.argmin (-5.0, 5.0) 0.01 (call fp))
    fun () -> Midpoint.methodName, (Midpoint.argmin (-5.0, 5.0) 0.01 (call fp))
    fun () -> Polyline.methodName, (Polyline.argmin (-5.0, 5.0) 0.01 (call fp) (call f))
]

let benchmark action =
    let stopwatch = Diagnostics.Stopwatch()
    stopwatch.Start()
    let result = action()
    stopwatch.Stop()
    let time = stopwatch.Elapsed
    time, result

[<EntryPoint>]
let main argv =
    let results = 
        List.map benchmark optimizations
        |> List.sortBy (fun (time, _) -> time)
    for line in results do
        match line with
        | time, (name, x) -> printfn "%-30s %-14f %A" name x time
    0
