module Palindrom

open System

let rec revAcc xs acc =
    match xs with
    | [] -> acc
    | h::t -> revAcc t (h::acc)

let rev xs =
    match xs with
    | [] -> xs
    | [_] -> xs
    | h1::h2::t -> revAcc t [h2;h1]

let toLower =
    String.map Char.ToLowerInvariant

let revString s =
    s
    |> List.ofSeq
    |> rev
    |> Seq.map string
    |> String.concat ""

let isPalindrom s =
    (s |> toLower) = (s |> toLower |> revString)

let isPalindromEasy (s: string) =
    let arr = s.ToLower().ToCharArray()
    arr = Array.rev arr