namespace BlazeAstro.Web.Shared.Models.Api
{
    public class ApiResponse
    {
        public string ErrorMessage { get; set; }
    }

    public class ApiResponse<TOutput>
        where TOutput : class
    {
        public string ErrorMessage { get; set; }

        public TOutput Data { get; set; }
    }
}