module Optimization.Newton

let methodName = "Метод Ньютона"

let argmin x (accuracy: float) primeFunc func =
    let rec r_argmin x xprev =
        match abs (x - xprev) > accuracy with
        | false -> x
        | true  -> r_argmin (x - func(x) / primeFunc(x)) x
    r_argmin x (x - (accuracy * 2.0))