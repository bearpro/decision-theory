module Functions

open System

type Expr =
    | Val of float
    | Var of string
    | Add of Expr * Expr
    | Mul of Expr * Expr

let rec diff f x =
    match f with
    | Var y when x=y -> Val 1.0
    | Val _ | Var _ -> Val 0.0
    | Add(f, g) -> Add(diff f x, diff g x)
    | Mul(f, g) -> Add(Mul(f, diff g x), Mul(g, diff f x))

let rec call expr x =
    match expr with
    | Val number -> number
    | Var "x" -> x
    | Var var -> sprintf "Variable '%s' not allowed." var |> failwith
    | Add(a, b) -> (call a x) + (call b x)
    | Mul(a, b) -> (call a x) * (call b x)
