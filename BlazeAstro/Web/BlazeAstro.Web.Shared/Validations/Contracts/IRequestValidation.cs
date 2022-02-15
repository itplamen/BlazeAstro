namespace BlazeAstro.Web.Shared.Validations.Contracts
{
    public interface IRequestValidation<TRequest>
        where TRequest : class
    {
        (bool IsSuccess, string ErrorMessage) Validate(TRequest inputModel);
    }
}