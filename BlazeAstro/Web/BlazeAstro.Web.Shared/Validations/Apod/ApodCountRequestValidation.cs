namespace BlazeAstro.Web.Shared.Validations.Apod
{
    using System;

    using BlazeAstro.Web.Shared.Models.Apod;
    using BlazeAstro.Web.Shared.Validations.Contracts;

    public class ApodCountRequestValidation : IRequestValidation<ApodInputModel>
    {
        public (bool IsSuccess, string ErrorMessage) Validate(ApodInputModel inputModel)
        {
            if (inputModel.Count > 0 && 
                (inputModel.Date != default(DateTime) ||
                inputModel.StartDate != default(DateTime) ||
                inputModel.EndDate != default(DateTime)))
            {
                return (false, $"'{nameof(inputModel.Count)}' cannot be used in conjunction with dates");
            }

            return (true, null);
        }
    }
}