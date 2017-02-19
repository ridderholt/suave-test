#r "./packages/Suave/lib/net40/Suave.dll"
#load "./fizzBuzz.fsx"
#load "./person.fsx"

open Suave
open Suave.Filters
open Suave.Operators    
open Suave.Successful
open FizzBuzz
open Person

let start : WebPart = 
    path "/" >=> choose [ GET >=> OK "Hello World!" ]

let app = [start;FizzBuzz.route;Persons.route]


startWebServer defaultConfig (choose app)



