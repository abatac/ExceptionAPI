using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WasteManagementAPI.Validation
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ValidationResultModel validationResult) : base(validationResult)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }

        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
