// Define types
type CurrentAccount = {
    AccountNumber: string
    Balance: decimal
}

type SavingsAccount = {
    AccountNumber: string
    Balance: decimal
    InterestRate: decimal
    MinimumBalance: decimal
}

type MobileMoneyAccount = {
    MobilePhoneNumber: string
    Balance: decimal
}

// Create instances
let myCurrentAccount = {
    AccountNumber = "23423434"
    Balance = 10_000m
}

let mySavingsAccount = {
    AccountNumber = "23424234234"
    Balance = 10_000m
    InterestRate = 10m
    MinimumBalance = 5_000m
}

let myMobileMoneyAccount = {
    MobilePhoneNumber = "+257721212313"
    Balance = 10_000m
}

// Define discriminated union
type Account =
    | Current of CurrentAccount
    | Savings of SavingsAccount
    | MobileMoney of MobileMoneyAccount
    

// Create a list of Account
let accounts : Account list = [
    Current myCurrentAccount
    Savings mySavingsAccount
    MobileMoney myMobileMoneyAccount
]
    
// Iterate and print details
accounts |> List.iter (fun account ->
    match account with
    | Current acc -> printfn "Current Account: %s, Balance: %s" acc.AccountNumber (acc.Balance.ToString("#,0"))
    | Savings acc -> printfn "Savings Account: %s, Rate: %M%%, Balance: %s" acc.AccountNumber acc.InterestRate (acc.Balance.ToString("#,0"))
)