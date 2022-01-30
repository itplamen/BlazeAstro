namespace BlazeAstro.Web.Shared.Validations.Apod
{
    using System;

    using BlazeAstro.Web.Shared.Models.Apod;

    public class ApodDateRequestValidation : IApodRequestValidation
    {
        public (bool IsSuccess, string ErrorMessage) Validate(ApodInputModel inputModel)
        {
            if (inputModel.Date != default(DateTime) && 
                (inputModel.StartDate != default(DateTime) || inputModel.EndDate != default(DateTime)))
            {
                string error = $@"'{nameof(inputModel.Date)}' cannot be used in conjunction with 
                    '{nameof(inputModel.StartDate)}' and '{nameof(inputModel.EndDate)}'";

                return (false, error);
            }

            return (true, null);
        }
    }
}