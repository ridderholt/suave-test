#r "./packages/Suave/lib/net40/Suave.dll"
#r "./packages/Newtonsoft.Json/lib/net40/Newtonsoft.Json.dll"

open Suave
open Suave.Filters
open Suave.Operators    
open Suave.Successful
open Newtonsoft.Json

module Persons = 

    type Person = {
        firstName : string
        lastName : string
        age : int
    }

    let getPersons =  [{firstName = "Robin"; lastName = "Ridderholt"; age = 31};
                      {firstName = "Susanne"; lastName = "Löfström"; age = 31}]
                      |> JsonConvert.SerializeObject


    
    let route : WebPart = 
        path "/persons" >=> choose [GET >=> OK getPersons]