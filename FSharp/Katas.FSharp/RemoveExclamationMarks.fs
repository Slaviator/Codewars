module RemoveExclamationMarks

open System

let removeExclamationMarks (s:string):string =
    s
    |> Seq.filter ((<>) '!')
    |> String.Concat

let removeExclamationMarksEasy = String.filter ((<>) '!')