namespace BlazeAstro.Services.DataProviders.Utilities
{
    using System.Collections.Generic;
    using System.Linq;

    using BlazeAstro.Services.Models.Contracts;

    public static class QueryStringBuilder
    {
        public static IDictionary<string, string> Build(IRequest request)
        {
            var queryString = new Dictionary<string, string>();
            var properties = request.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (prop.CustomAttributes.Any())
                {
                    string name = prop.CustomAttributes.First().ConstructorArguments.First().Value?.ToString();
                    string value = prop.GetValue(request)?.ToString();

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                    {
                        if (prop.PropertyType != typeof(int) ||
                            (int.TryParse(value, out int result) &&
                            result != 0))
                        {
                            queryString.Add(name, value);
                        }
                    }
                }
            }

            return queryString;
        }
    }
}
