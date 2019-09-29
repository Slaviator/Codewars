module RemoveExclamationMarksTests

open Xunit
open RemoveExclamationMarks

[<Theory>]
[<InlineData("Hello World", "Hello World!")>]
let ``removeExclamationMarks returns string without exclamation characters`` (expected:string, value:string) =
    Assert.Equal(expected, removeExclamationMarks value)