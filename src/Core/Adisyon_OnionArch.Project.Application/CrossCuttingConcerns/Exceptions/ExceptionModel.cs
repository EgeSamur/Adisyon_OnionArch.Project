using System.Text.Json;

namespace Adisyon_OnionArch.Project.Application.CrossCuttingConcerns.Exceptions
{
    public class ExceptionModel 
    {
        public IEnumerable<string> Errors { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }); ;
        }
    }
}
