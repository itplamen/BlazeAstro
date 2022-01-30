namespace BlazeAstro.Web.Shared.Validations.Apod
{
    using System;

    using BlazeAstro.Web.Shared.Models.Apod;

    public class ApodDateRangesRequestValidation : IApodRequestValidation
    {
        public (bool IsSuccess, string ErrorMessage) Validate(ApodInputModel inputModel)
        {
            if (inputModel.StartDate == default(DateTime) && inputModel.EndDate != default(DateTime))
            {
                return (false, $"'{nameof(inputModel.StartDate)}' is missing");
            }

            if (inputModel.StartDate > inputModel.EndDate)
            {
                return (false, $"'{nameof(inputModel.StartDate)}' cannot be after '{nameof(inputModel.EndDate)}'");
            }

            return (true, null);
        }
    }
}