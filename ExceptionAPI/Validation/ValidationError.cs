using Newtonsoft.Json;

namespace WasteManagementAPI.Validation
{
    public class ValidationError
    {
        [JsonProperty(PropertyName = "field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
