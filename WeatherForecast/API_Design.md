# City Weather Forecast API Design
In here there are several endpoints described to support further expansion of the project functionalities. 
Some of these already exist and are supported, others still need further work.

## Endpoint

- Get the city weather for a chosen day
```
GET /api/v3/cities/{id}/day/{day}

$ curl -X GET '/api/v3/cities/{id}/day/{day}' 
```

- Set the city weather for a chosen day. This endpoint requires a OAuth authentication token.
```
PUT /api/v3/cities/{id}/day/{day}

$ curl -X PUT '/api/v3/cities/{id}/day/{day}' \
    -H 'Authorization: Bearer {accessToken}'  \
    -d "{weather}"
```
