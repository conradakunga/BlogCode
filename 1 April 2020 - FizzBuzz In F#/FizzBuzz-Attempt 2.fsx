// Create a helper function to do the checks
let DivisibleBy x y = y % x = 0
// Create a list of 100 elements
[ 1 .. 100 ]
// Iterate through the list
|> List.iter (function
    // Check for modulus division for 3 and 5
    | x when DivisibleBy 3 x && DivisibleBy 5 x -> printfn "fizzbuzz"
    // Check for modulus division for 3
    | x when DivisibleBy 3 x -> printfn "fizz"
    // Check for modulus division for 5
    | x when DivisibleBy 5 x -> printfn "buzz"
    // Print the rest
    | x -> printfn "%i" x)
