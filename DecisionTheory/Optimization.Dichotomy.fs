module Optimization.Dichotomy

let rec argmin func (a, b) d accuracy =
    if (b - a) <= accuracy 
    then (b + a) / 2.
    else
        let x1 = (b+a-d) / 2.
        let x2 = (b+a+d) / 2.
        let y1 = func x1
        let y2 = func x2
        match y1 <= y2 with
        | true  -> argmin func (a, x2) d accuracy
        | false -> argmin func (x1, b) d accuracy