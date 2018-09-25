using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionAPI.Validation
{
    public class ValidationResultModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<ValidationError> Errors { get; set; }

        public ValidationResultModel()
        {

        }

        public ValidationResultModel(string message)
        {
            Message = message;
        }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
            Message = "Validation Failed";
        }
    }
}
