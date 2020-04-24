#r "nuget: Newtonsoft.Json"

open Newtonsoft.Json
open System.Net.Http
open System

// 
// Declare our types
//

// The first is the rested response
type Values = {Sunrise: DateTimeOffset; Sunset : DateTimeOffset; Day_Length:TimeSpan}
// This is the top level response
type Response = {Status : string; Results: Values}

//
// Now fetch the data
//

// Create a httpclient
let client = new HttpClient()
// pull down the JSON
let json = client.GetStringAsync("https://api.sunrise-sunset.org/json?lat=1.2921&lng=36.8219").Result
// Deserialize the object
let obj = JsonConvert.DeserializeObject<Response>(json)
// Print the values to screen
printf "Sunrise is at %s\n" (obj.Results.Sunrise.ToString())
printf "Sunset at %s\n" (obj.Results.Sunset.ToString())
printf "Day Length is  %s" (obj.Results.Day_Length.ToString())


    
