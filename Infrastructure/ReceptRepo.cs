//domain entity - har id av något slag, behöver inte ha samma id som domain entity. 

namespace ReceptBank.Infrastructure;

using ReceptBank.Domain;

//ärver från Domain IReceptRepo
//konvertera saker annars kan den inte få ut kontraktet

public class ReceptRepo : IReceptRepo
{
    public Recept GetReceptById(int id)
    {
        //TODO skriv rätt
        return new Recept("mocka", "mocka2"); // Mock implementation
    }   
    
      public List<Recept> GetRecepts()
        {
            List<Recept> recipes = new List<Recept>();

            // Adding sample recipes with names and ingredients
            recipes.Add(new Recept("Recipe 1", "Ingredient 1, Ingredient 2"));
            recipes.Add(new Recept("Recipe 2", "Ingredient 3, Ingredient 4"));
            recipes.Add(new Recept("Recipe 3", "Ingredient 5, Ingredient 6"));

            return recipes;
        }
}

