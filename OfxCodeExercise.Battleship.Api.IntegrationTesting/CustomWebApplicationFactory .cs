using Microsoft.AspNetCore.Mvc.Testing;
using OfxCodeExercise.Battleship.Api.StateTracker;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OfxCodeExercise.Battleship.Api.IntegrationTesting
{
    public class CustomWebApplicationFactory: WebApplicationFactory<Startup>
    {
        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("My-Header", "Battleship api integration testing");
            base.ConfigureClient(client);
        }
    }
}
