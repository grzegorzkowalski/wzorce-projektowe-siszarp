# Zadanie 1

## 1. Dodaj w solucji nowy projekt konsolowy .NET 8 (w solution explorer lub komend¹).
dotnet new console -n WeatherKiota -f net8.0 --force
cd WeatherKiota
Dodaj projekt do solucji jeœli uzy³eœ konsoli.

## 2. Dodaj paczkê bundle Kiota.
dotnet add package Microsoft.Kiota.Bundle

## 3. Zainstaluj Kiota CLI (lokalnie w repo – polecane).
dotnet new tool-manifest
dotnet tool install Microsoft.OpenApi.Kiota

## 3. Uruchom Weather API.

## 4. Wygeneruj klienta z WeatherAPI OpenAPI do folderu GeneratedClient.
dotnet tool run kiota generate \
  -l CSharp \
  -c WeatherClient \
  -n WeatherKiota.Generated \
  -d https://localhost:7191/swagger/v1/swagger.json \
  -o ./GeneratedClient
  
## 5. W projekcie WeatherKiota dodaj przyk³adowy kod do pliku Program.cs.
```
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using WeatherKiota.Generated;

var auth = new AnonymousAuthenticationProvider();
var httpClient = new HttpClient();
var adapter = new HttpClientRequestAdapter(auth)
{
    BaseUrl = "https://localhost:7191"
};

// Utwórz klienta
var client = new WeatherClient(adapter);

var forecasts = await client.WeatherForecast.GetAsync();

foreach (var f in forecasts!)
{
    Console.WriteLine($"{f.Date}: {f.Summary} ({f.TemperatureC}°C)");
}
```

## 6. Uruchom w dowolny znany Ci sposób oba projekty (najpierw API).


# Zadanie 2

## Wygeneruj projekt na podstawie specyfikacji `https://petstore3.swagger.io/api/v3/openapi.json`.