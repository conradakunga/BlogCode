// Fold over the list using addition; starting from an initial sum on 0
printfn "%i" (List.fold (+) 0 [ 5; 10; 15 ])

// Fold can also be simplified with reduce
printfn "%i" (List.reduce(+)[ 5; 10; 15 ])

// Above is equivalent to this; but was demonstrating how the addiion is done
printfn "%i" (List.sum [ 5; 10; 15 ])
