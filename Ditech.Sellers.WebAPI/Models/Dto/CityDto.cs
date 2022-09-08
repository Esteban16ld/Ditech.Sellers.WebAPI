using System.Text.Json.Serialization;

namespace Ditech.Sellers.WebAPI.Data.Models.Dto
{
    public class CityDto
    {
        [JsonPropertyName("Description")]
        public string DESCRIPTION { get; set; }
    }
}
