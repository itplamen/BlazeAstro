namespace BlazeAstro.Services.DataProviders
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using AngleSharp.Html.Dom;
    using AngleSharp.Html.Parser;

    using Newtonsoft.Json;

    using BlazeAstro.Services.DataProviders.Contracts;
    using BlazeAstro.Services.Models.Astronauts.AstronautInfo;
    using BlazeAstro.Services.Models.Astronauts.AstronautsInSpace;

    public class AstronautsDataProvider : IDataProvider<AstronautsRequestModel, AstronautsResponseModel>, IDataProvider<AstronautInfoRequestModel, AstronautInfoResponseModel>
    {
        private readonly HttpClient httpClient;
        private readonly IHtmlParser htmlParser;

        public AstronautsDataProvider(HttpClient httpClient, IHtmlParser htmlParser)
        {
            this.httpClient = httpClient;
            this.htmlParser = htmlParser;
        }

        public async Task<AstronautsResponseModel> GetData(AstronautsRequestModel request)
        {
            var response = await httpClient.GetAsync(request.Url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AstronautsResponseModel>(content);

            foreach (var astronaut in result.Astronauts)
            {
                astronaut.Name = astronaut.Name.Replace(" ", "-");
            }

            return result;
        }

        public async Task<AstronautInfoResponseModel> GetData(AstronautInfoRequestModel request)
        {
            var response = await httpClient.GetAsync(request.Url);
            var content = await response.Content.ReadAsStringAsync();
            var document = htmlParser.ParseDocument(content);

            var result = new AstronautInfoResponseModel();
            result.DateOfBirth = GetDateOfBirth(document);
            result.ImgUrl = document.QuerySelectorAll("article .img-fluid").Last().Attributes["src"].Value;
            result.AstronautInfo = document.QuerySelector("article div.entry-content p.astronaut-description").TextContent;
            result.SpaceAgencyName = document.QuerySelectorAll("article div.entry-content h2.h5").Last().InnerHtml;
            result.SpaceAgencyInfo = document.QuerySelectorAll("article div.entry-content p").Last().PreviousSibling.TextContent;

            return result;
        }

        private string GetDateOfBirth(IHtmlDocument document)
        {
            string innerText = document.QuerySelector("article div.entry-content").ChildNodes[0].TextContent;
            int startIndex = innerText.IndexOf("\n");
            int endIndex = innerText.IndexOf("\n", startIndex + 1);

            string dateOfBirth = innerText.Substring(startIndex, endIndex - startIndex)
                .Replace("\n", string.Empty)
                .Replace("–", string.Empty)
                .Trim();

            return dateOfBirth;
        }
    }
}