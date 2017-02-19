#r "./packages/Suave/lib/net40/Suave.dll"
#r "./packages/Newtonsoft.Json/lib/net40/Newtonsoft.Json.dll"

open Suave
open Suave.Filters
open Suave.Operators    
open Suave.Successful
open Newtonsoft.Json

module FizzBuzz = 

    let fizz tpl = 
        match tpl with
        | (0, 0, _) -> "FizzBuzz"
        | (0, _, _) -> "Fizz"
        | (_, 0, _) -> "Buzz"
        | (_, _, x) -> string x

    let createTuple i = (i%3, i%5, i)

    let buzz i = i |> createTuple |> fizz

    let get = [1..20] |> List.map buzz
                      |> JsonConvert.SerializeObject

    let route : WebPart = 
        path "/fizz" >=> choose [ GET >=> OK get ]