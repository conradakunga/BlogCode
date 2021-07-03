module ZooTest

open NUnit.Framework
open Zoo
open FsUnit

[<SetUp>]
let Setup () = ()

[<Test>]
let ``Lion Is Created Correctly`` () =
    let simba = Lion(Name = "Simba")
    simba |> should not' (be null)

[<Test>]
let ``Tiger Is Created Correctly`` () =
    let tigger = Tiger(Name = "Tigger")
    tigger |> should not' (be null)

[<Test>]
let ``Bear Is Created Correctly`` () =
    let yogi = Bear(Name = "Yogi")
    yogi |> should not' (be null)

[<Test>]
let ``Snake Is Created Correctly`` () =
    let steven = Snake(name = "Steven")
    steven |> should not' (be null)
