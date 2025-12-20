# WeatherWrapperAPI

RESTful API developed in **ASP.NET Core (.NET 8)** following the rules of the challenge proposed at:

https://roadmap.sh/projects/weather-api-wrapper-service

The application allows weather queries, returning only necessary values ​​without data pollution.

Implementing Redis(STILL TO IMPLEMENT) for caching and system optimization, and also adding rate limiting requests to avoid DDoS attacks.


<img width="2048" height="1059" alt="image" src="https://github.com/user-attachments/assets/a1961448-efc3-472d-b0a3-82cb1ddc82d2" />

--------------------------------------------------------------------------------------

## Architectural desition
I opted for **N-Layered** architecture over Clean Architecture because I realized it would be over-engineering. Since it's an API wrapper without domain logic and complex behaviors, Clean Architecture would only add unnecessary complexity.

--------------------------------------------------------------------------------------

## Technologies and Patterns Used

- **.NET 8**
- **ASP.NET Core Web API**
- **IOptions Patterns**
- **Repository Pattern**
- **N-Layered Architecture**
- **Dependency Injection (DI)**
- **Swagger / Swashbuckle** (for documentation)
- **DataAnnotations** (for validations)

--------------------------------------------------------------------------------------

## How execute this project

### Pré-requisitos

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [Visual Crossing APY Key](https://www.visualcrossing.com/weather-api/)

### Steps

1.  Clone the repository:

    ``` bash
    git clone https://github.com/KayronJ/WeatherWrapperAPI.git
    cd WeatherWrapperAPI
    ```

2.  Configure an **ApiKey** on `appsettings.json`.


3.  Execute the API:

    ``` bash
    dotnet run --project WeatherWrapperAPI
    ```

5.  Access Swagger Documentation:

        https://localhost:7172/swagger
