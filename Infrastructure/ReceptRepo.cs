//domain entity - har id av något slag, behöver inte ha samma id som domain entity. 

namespace ReceptBank.Infrastructure;

using ReceptBank.ApplicationServices;
using ReceptBank.Domain;

//ärver från Domain IReceptRepo
//konvertera saker annars kan den inte få ut kontraktet

public class ReceptRepo : IReceptRepo
{
    public Recept Edit(Recept originalRecept)
    {
        throw new NotImplementedException();
    }

    public Recept Edit()
    {
        throw new NotImplementedException();
    }

    public Recept Edit(ReceptDTO updatedRecept)
    {
        throw new NotImplementedException();
    }

    public ReceptDTO GetReceptById(int id)
    {
        //TODO skriv rätt
        return new ReceptDTO("mocka", "mocka2", 2); // Mock implementation
    }   
    
      public List<Recept> GetRecepts()
        {
            List<Recept> recipes = new List<Recept>();

            // Adding sample recipes with names and ingredients
            recipes.Add(new Recept("Recipe 1", "Ingredient 1, Ingredient 2", 1));
            recipes.Add(new Recept("Recipe 2", "Ingredient 3, Ingredient 4", 2));
            recipes.Add(new Recept("Recipe 3", "Ingredient 5, Ingredient 6", 3));

            return recipes;
        }
};
