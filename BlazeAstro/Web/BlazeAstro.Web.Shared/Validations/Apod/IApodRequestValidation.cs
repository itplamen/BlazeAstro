namespace BlazeAstro.Web.Shared.Validations.Apod
{
    using BlazeAstro.Web.Shared.Models.Apod;

    public interface IApodRequestValidation
    {
        (bool IsSuccess, string ErrorMessage) Validate(ApodInputModel inputModel);
    }
}
