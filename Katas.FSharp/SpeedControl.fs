module SpeedControl

let speed distance period = int ((3600. * distance) / (float period))

let gps period distances =
    match distances with
    | [] -> 1
    | [_] -> 1
    | xs ->
        xs
        |> Seq.pairwise
        |> Seq.map (fun (a,b) -> speed (b-a) period)
        |> Seq.max

let rec gpsOther period distances =
    match distances with
    | [] -> 1
    | _ :: [] -> 1
    | a :: b :: xs -> max (speed (b-a) period) (gpsOther period (b :: xs))