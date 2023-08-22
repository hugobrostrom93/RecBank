//en fil som läser och implementera funktioner i db
//implementation av hur man i praktiken gör - fil.json som läser den. ReadFromFile  
//översätta till lista av recept enteties json
//kan göras på många olika sätt - tex mongoDB osv
//ärver av interface klassen (skapa en sån)
//måste känna till domain namespace (skapa)

using System.Text.Json;
using ReceptBank.ApplicationServices;
using ReceptBank.Domain;

namespace ReceptBank.Infrastructure;
public class ReceptRepoJson : IReceptRepo
{
    private readonly string _filePath = "Recept.json";

    public Recept GetReceptById(int id)
    {
        var recept = ReadFromFile();
        var receptData = recept.Find(p => p.ReceptId == id);

        return receptData != null ? new Recept(receptData.Name, receptData.Ingredients) : null;
        //den här raden som vi tar en data entitet och skapar till en domain entitet, different types?
    }

    public List<Recept> GetRecepts()
    {
      
            var recept = ReadFromFile();
            
            // Transform the List<ReceptData> into a List<Recept>
            var receptData = recept.Select(receptData => new Recept(receptData.Name, receptData.Ingredients)).ToList();
            
            return receptData;          
    }
   

    //public List<Score>? GetScore() => JsonConvert.DeserializeObject<List<Score>>(File.ReadAllText(Path));
    
    private List<ReceptEntityJson> ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            
            return JsonSerializer.Deserialize<List<ReceptEntityJson>>(json) ?? new List<ReceptEntityJson>();
        }

        return new List<ReceptEntityJson>();
    }

}