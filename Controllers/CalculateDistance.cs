using Microsoft.AspNetCore.Mvc;
using SocialBrothersWebAPICase.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialBrothersWebAPICase.Controllers
{
    public class CalculateDistance : ControllerBase
    {
        private readonly AddressesContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public CalculateDistance(IHttpClientFactory httpClientFactory, AddressesContext Context)
        {
            _httpClientFactory = httpClientFactory;
            _context = Context;

        }

        [HttpGet]
        public async Task<ActionResult<double>> GetDistance(int id1, int id2)
        {
            // Retrieve the two addresses from the database
            var address1 = await _context.Address.FindAsync(id1);
            var address2 = await _context.Address.FindAsync(id2);

            // Url for the public API
            var url = $"https://api.distancematrix.ai/maps/api/distancematrix/json?origins={address1}&destinations={address2}&key=AIzaSyARR126WaEUg4tb6gHHa6XAh8w5l5ICq10";

            // Send the request
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsAsync<DistanceMatrixApiResponse>();

            // Check for errors
            if (result.Status != "OK")
            {
                return BadRequest($"Failed to retrieve distance: {result.ErrorMessage}");
            }

            // Extract the distance from the API
            var distance = double.Parse(result.Rows[0].Elements[0].Distance.Value);
            return distance;
        }

        public class DistanceMatrixApiResponse
        {
            public string Status { get; set; }
            public string ErrorMessage { get; set; }
            public DistanceMatrixApiResponseRow[] Rows { get; set; }
        }

        public class DistanceMatrixApiResponseRow
        {
            public DistanceMatrixApiResponseElement[] Elements { get; set; }
        }

        public class DistanceMatrixApiResponseElement
        {
            public DistanceMatrixApiResponseValue Distance { get; set; }
        }

        public class DistanceMatrixApiResponseValue
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

    }
}
