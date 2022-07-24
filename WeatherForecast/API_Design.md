# City Weather Forecast API Design
In here there are several endpoints described to support further expansion of the project functionalities. 
Some of these already exist and are supported, others still need further work.

## Endpoint

- Get the city weather for a chosen day
```
GET /api/v3/cities/{city}/day/{day}

$ curl -X GET '/api/v3/cities/{city}/day/{day}' 
```
This will return a string with the weather for the passed day parameter in the city chosen.
The day must be 1 for today and +1 for each day in advance we want to target, meaning tomorrow would be 2 the next day a 3 and so on.

Example - "What's the weather today?":
```
$ curl -X GET '/api/v3/cities/Lisboa/day/1' 
```
Will return "Sunny".

- Set the city weather for a chosen day. This endpoint requires a OAuth authentication token.
```
PUT /api/v3/cities/{city}/day/{day}

$ curl -X PUT '/api/v3/cities/{city}/day/{day}' \
    -H 'Authorization: Bearer {accessToken}'  \
    -d "{weather}"
```
