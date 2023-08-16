//skriva och läsa i json filen


using System.Text.Json.Serialization;

namespace ReceptBank.Infrastructure;
public class ReceptEntityJson
{
    [JsonPropertyName("recept_id")]
    public int ReceptId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("ingredients")]
    public string Ingredients { get; set; }

}
