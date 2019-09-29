module SpeedControlTests

open System
open SpeedControl
open Xunit

let memberData() =
    seq {
        yield [|1 :> Object; 15 :> Object;
            [0.0] :> Object|]
        yield [|74 :> Object; 15 :> Object;
            [0.0; 0.19; 0.5; 0.75; 1.0; 1.25; 1.5; 1.75; 2.0; 2.25] :> Object|]
        yield [|41 :> Object; 20 :> Object;
            [0.0; 0.23; 0.46; 0.69; 0.92; 1.15; 1.38; 1.61] :> Object|]
        yield [|219 :> Object; 12 :> Object;
            [0.0; 0.11; 0.22; 0.33; 0.44; 0.65; 1.08; 1.26; 1.68; 1.89; 2.1; 2.31; 2.52; 3.25] :> Object|]
        yield [|80 :> Object; 20 :> Object;
            [0.0; 0.18; 0.36; 0.54; 0.72; 1.05; 1.26; 1.47; 1.92; 2.16; 2.4; 2.64; 2.88; 3.12; 3.36; 3.6; 3.84] :> Object|]
    }

[<Theory>]
[<MemberData("memberData")>]
let ``floor of max speed calculated properly`` (expected:int, period:int, distances:list<double>) =
        Assert.Equal(expected, gps period distances)
