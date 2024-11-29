// We need this for the Random class
open System

// Generate a list of numbers
let numbers = [ 0 .. 9 ]

// Wite a function that shuffles a passed list and returns a new one
let shuffle list =
    let rand = Random()
    list |> List.sortBy (fun _ -> rand.Next())

// Shuffle the numbers
let shuffledNumbers = shuffle numbers
printfn "Shuffled: %A" shuffledNumbers

let otherShuffledNumbers = numbers |> List.randomShuffle
printfn "Other Shuffled: %A" shuffledNumbers

let numbersArray = [0 .. 9] |> List.toArray
printfn "Original Array: %A" numbersArray

// Shuffle in place
numbersArray |> Array.randomShuffleInPlace
printfn "Original Array: %A" numbersArray
