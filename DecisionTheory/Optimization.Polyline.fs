module Optimization.Polyline

let methodName = "Метод ломаных отезков"

let calculateL func : float = 
    raise null

let argmin (a, b) accuracy (fp: float -> float) f =
    let L = [ a; b ]
            |> List.map (fp >> abs)
            |> List.max
    let rec r_argmin (a, b) =
        let x0 = (1.0 / (2.0 * L)) * ((f a) - (f b) + L * a + L * b)
        let p0 = 0.5 * ((f a) + (f b) + L * a - L * b)
        let d =  (1.0 / (2.0 * L)) * ((f x0) - p0)
        let x1p = x0 - d
        let x1pp = x0 + d
        let ld = 2.0 * L * d
        let y1p = fp x1p
        let y1pp = fp x1pp
        match ld > accuracy, abs(y1p) < abs(y1pp) with
        | true, true  -> r_argmin (a, x0)
        | true, false -> r_argmin (x0, b)
        | false, _    -> x0
    r_argmin (a, b)