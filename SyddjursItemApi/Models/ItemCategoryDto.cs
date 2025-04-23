using System.Text.Json.Serialization;

namespace SyddjursItemApi.Models
{
    public class ItemCategoryDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}
