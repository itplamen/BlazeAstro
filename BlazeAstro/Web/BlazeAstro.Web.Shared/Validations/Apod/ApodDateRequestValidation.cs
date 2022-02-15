namespace BlazeAstro.Web.Shared.Validations.Apod
{
    using System;

    using BlazeAstro.Web.Shared.Models.Apod;
    using BlazeAstro.Web.Shared.Validations.Contracts;

    public class ApodDateRequestValidation : IRequestValidation<ApodInputModel>
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