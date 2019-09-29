module PalindromTests

open Xunit
open Palindrom

[<Theory>]
[<InlineData(true, "a")>]
[<InlineData(true, "aba")>]
[<InlineData(true, "Abba")>]
[<InlineData(false, "hello")>]
let ``is palindrome can recognize both positive and negative cases`` (expected:bool, value:string) =
    Assert.Equal(expected, isPalindrom value)