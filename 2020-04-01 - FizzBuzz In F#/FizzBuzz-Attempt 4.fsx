// Create a helper function to do the checks
let DivisibleBy x y = y % x = 0
// Create a list of 100 elements
[ 1 .. 100 ]
// Iterate through the list and map each element to a new list
|> List.map (function
    // Check for modulus division for 3 and 5
    | x when DivisibleBy (3 * 5) x -> "fizzbuzz"
    // Check for modulus division for 3
    | x when DivisibleBy 3 x -> "fizz"
    // Check for modulus division for 5
    | x when DivisibleBy 5 x -> "buzz"
    // Output rest
    | x -> string x)
// Iterate through the new list and print the elements
|> List.iter (fun x -> printfn "%s" x)

