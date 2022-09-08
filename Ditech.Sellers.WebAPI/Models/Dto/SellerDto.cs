using System.Text.Json.Serialization;

namespace Ditech.Sellers.WebAPI.Models.Dto
{
    public class SellerDto
    {
        [JsonPropertyName("CODE")]
        public int? CODE { get; set; }
        [JsonPropertyName("NAME")]
        public string NAME { get; set; }
        [JsonPropertyName("LAST_NAME")]
        public string LAST_NAME { get; set; }
        [JsonPropertyName("DOCUMENT")]
        public string? DOCUMENT { get; set; }
        [JsonPropertyName("CITY_NAME")]
        public string CITY_NAME { get; set; }
    }
}
