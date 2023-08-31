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

   
    public Recept Edit(Recept originalRecept)
    {
        throw new NotImplementedException();
    }

    public Recept Edit()
    {
        throw new NotImplementedException();
    }

    public Recept GetReceptById(int id)
    {
        var recept = ReadFromFile();
        var receptData = recept.Find(p => p.ReceptId == id);

        return receptData != null ? new Recept(receptData.Name, receptData.Ingredients, receptData.ReceptId) : null;
        //den här raden som vi tar en data entitet och skapar till en domain entitet, different types?
    }

    public List<Recept> GetRecepts()
    {      
            var recept = ReadFromFile();
            
            // Transform the List<ReceptData> into a List<Recept> 
            var receptData = recept.Select(receptData => new Recept(receptData.Name, receptData.Ingredients, receptData.ReceptId)).ToList();
            
            return receptData;          
    }
    
    private List<ReceptEntityJson> ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            
            return JsonSerializer.Deserialize<List<ReceptEntityJson>>(json) ?? new List<ReceptEntityJson>();
        }

        return new List<ReceptEntityJson>();
    }

    public void Remove(int id)
    {
        var receptList = ReadFromFile();

        int index = receptList.FindIndex(receptData => receptData.ReceptId == id);

        if (index != -1)
        {
            receptList.RemoveAt(index);
            SaveToFile(receptList);
        }
    }

        private void SaveToFile(List<ReceptEntityJson> receptList)
        {
            var json = JsonSerializer.Serialize(receptList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

            public Recept Create(Recept newRecept)
        {
            var receptList = ReadFromFile();

            // Create a new ReceptEntityJson object based on the provided Recept
            var newReceptEntity = new ReceptEntityJson
            {
                ReceptId = GenerateNewId(), // Assuming you have a method to generate a new unique ID
                Name = newRecept.Name,
                Ingredients = newRecept.Ingredients
            };

            // Add the new ReceptEntityJson to the list
            receptList.Add(newReceptEntity);

            // Save the updated list back to the file
            SaveToFile(receptList);

            // Return the created Recept object (you might need to map ReceptEntityJson to Recept)
            return new Recept(newReceptEntity.Name, newReceptEntity.Ingredients, newReceptEntity.ReceptId);
        }

        private int GenerateNewId()
        {
            var receptList = ReadFromFile();

            // Find the highest existing ID
            int highestId = 0;
            foreach (var receptEntity in receptList)
            {
                if (receptEntity.ReceptId > highestId)
                {
                    highestId = receptEntity.ReceptId;
                }
            }

            // Increment the highest ID to generate a new unique ID
            int newUniqueId = highestId + 1;

            return newUniqueId;
        }

public Recept Add(string name, string ingredients)
    {
        var receptList = ReadFromFile();

        // Generate a new unique ID
        int newId = GenerateNewId();

        // Create a new ReceptEntityJson object based on the provided parameters
        var newReceptEntity = new ReceptEntityJson
        {
            ReceptId = newId,
            Name = name,
            Ingredients = ingredients
        };

        // Add the new ReceptEntityJson to the list
        receptList.Add(newReceptEntity);

        // Save the updated list back to the file
        SaveToFile(receptList);

        // Return the created Recept object (you might need to map ReceptEntityJson to Recept)
        return new Recept(newReceptEntity.Name, newReceptEntity.Ingredients, newReceptEntity.ReceptId);
    }
}


