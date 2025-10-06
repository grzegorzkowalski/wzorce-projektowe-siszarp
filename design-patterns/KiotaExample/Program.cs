using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Bundle;
using Microsoft.Kiota.Http.HttpClientLibrary;

// *** UWAGA ***
// Po wygenerowaniu klienta z Kiota będziesz mieć przestrzeń nazw i typy
// zgodne z parametrem -n oraz -c. Poniżej używamy:
//   namespace: PetstoreKiota.Generated
//   root client: PetStoreClient
using PetstoreKiota.Generated;
using PetstoreKiota.Generated.Models;
using System.Net.Http;
// Initialize the request adapter with an anonymous authentication provider
// In real-world scenarios, you would use appropriate authentication
var requestAdapter = new DefaultRequestAdapter(new AnonymousAuthenticationProvider());

// Create a new instance of our generated client
var client = new PetStoreClient(requestAdapter);

var createdPet = await client.WeatherForecast.GetAsync();
Console.WriteLine(createdPet?.Count);
