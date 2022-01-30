﻿namespace BlazeAstro.Services.DataProviders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.WebUtilities;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Apod;

    public class ApodDataProvider : IDataProvider<ApodRequestModel, IEnumerable<ApodResponseModel>>
    {
        private const string BASE_URL = "https://api.nasa.gov/planetary/apod";

        private readonly HttpClient httpClient;

        public ApodDataProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ApodResponseModel>> GetData(ApodRequestModel request)
        {
            var queryString = new Dictionary<string, string>();
            var properties = request.GetType().GetProperties();

            foreach (var prop in properties)
            {
                string name = prop.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
                string value = prop.GetValue(request)?.ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    if (prop.PropertyType != typeof(int) ||
                        (int.TryParse(value, out int result) &&
                        result != 0))
                    {
                        queryString.Add(name, value);
                    }
                }
            }

            string url = QueryHelpers.AddQueryString(BASE_URL, queryString);
            var response = await httpClient.GetFromJsonAsync<IEnumerable<ApodResponseModel>>(url);

            return response;
        }
    }
}