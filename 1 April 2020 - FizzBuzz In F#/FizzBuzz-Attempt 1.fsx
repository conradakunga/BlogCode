// Create a list of 100 elements
[ 1 .. 100 ]
// Iterate through the list
|> List.iter (function
    // Check for modulus division for 3 and 5
    | x when x % 3 = 0 && x % 5 = 0 -> printfn "fizzbuzz"
    // Check for modulus division for 3
    | x when x % 3 = 0 -> printfn "fizz"
    // Check for modulus division for 5
    | x when x % 5 = 0 -> printfn "buzz"
    // Print the rest
    | x -> printfn "%i" x)
