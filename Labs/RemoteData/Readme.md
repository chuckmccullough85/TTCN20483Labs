## Overview
Get some data from a remote source and process it.

| | |
| --------- | --------------------------- |
| Exercise Folder | RemoteData |
| Builds On | None |
| Time to complete | 30 minutes

Let's build a console application that fetches and processes cryptocurrency data from a remote source.

We will be using [CoinCap API](https://docs.coincap.io/) to fetch the data.

## Steps
1. Create a new console application.
2. Open a browser and navigate to https://api.coincap.io/v2/assets
    - examine the Json response and use it to define `record` types in your application.
    - There are 2 types in the response:  The top object contains 1 field, *data*.  The *data* field is an array of objects.  Each object in the array represents a cryptocurrency.  Define a record type for the cryptocurrency object.  The fields in the cryptocurrency object are:
        - id
        - rank
        - symbol
        - name
        - supply
        - maxSupply
        - marketCapUsd
        - volumeUsd24Hr
        - priceUsd
        - changePercent24Hr
        - vwap24Hr
        - explorer
    - You may not be interested in all the fields.  Just define the fields you are interested in.
    - All of the fields are strings, but you may want to convert some of them to other types.  For instance, rank is a string, but you may want to convert it to an integer.  Price is a string, but you may want to convert it to a decimal.  You can do this in the record definition.
    - Some of the fields can be null.  Declare nullable types for these fields.

3. Use the `HttpClient` class to fetch the data from the remote source. Use the URL from step 2.
3. Create a `JsonSerializerOptions` object and set `PropertyNameCaseInsensitive` to `true`. Also set `NumberHandling` to `JsonNumberHandling.AllowReadingFromString`.
    - You will need some `using namespace`s!
4. Use the `System.Text.Json.JsonSerializer` class to deserialize the Json response into a collection of the record type you defined in step 2.
5. Print the data to the console.
