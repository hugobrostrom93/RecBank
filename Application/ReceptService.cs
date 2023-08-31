

namespace ReceptBank.ApplicationServices;

using System.Reflection.Metadata.Ecma335;
using ReceptBank.Domain;

public class ReceptService : IReceptService
{
    private readonly IReceptRepo _receptRepository;

    public ReceptService(IReceptRepo receptRepository)
    {
        _receptRepository = receptRepository;
    }
    
    public ReceptDTO Edit(int id)
    {
        throw new NotImplementedException();
    }

    public List<ReceptDTO> GetRecepts()
    {
        // Get a list of Recept objects from the repository
        var recepts = _receptRepository.GetRecepts();

        // Create a list of ReceptDTO objects
        var receptDTOs = new List<ReceptDTO>();

        foreach (var recept in recepts)
        {
            var receptDTO = new ReceptDTO
            {
                Name = recept.Name,
                Ingredients = recept.Ingredients,
                ReceptId = recept.ReceptId
            };

            receptDTOs.Add(receptDTO);
        }

        return receptDTOs;
    }


    public ReceptDTO Edit(int id, ReceptDTO updatedRecept)
    {
        // Get the original Recept object from the repository
        var originalRecept = _receptRepository.GetReceptById(id);

        // Update properties of the originalRecept based on updatedRecept

        // Call a method on the repository to save changes
        _receptRepository.Edit(originalRecept);

        // Return a ReceptDTO representing the updated recipe
        return new ReceptDTO
        {
            Name = originalRecept.Name,
            Ingredients = originalRecept.Ingredients
        };
    }

        public void Remove(int id)
        {
            // Call the repository's Remove method to remove the recipe
            _receptRepository.Remove(id);
        }

    // public ReceptDTO Remove(int id)
    // {
    //     var recept = _receptRepository.GetReceptById(1);
    //     return new ReceptDTO
    //     {
    //         // Recipes.Remove(Recept);
    //         // _context.SaveChanges();
    //     };

    // }
    //implement logic for editing recept 

public ReceptDTO Create(ReceptDTO newRecept)
{
    // Call the repository's method to add the new recipe
    var addedRecipe = _receptRepository.Add(newRecept.Name, newRecept.Ingredients);

    // Assuming _receptRepository.Add returns the newly added Recept object,
    // you can then create a ReceptDTO from it and return it
    return new ReceptDTO
    {
        Name = addedRecipe.Name,
        Ingredients = addedRecipe.Ingredients,
        ReceptId = addedRecipe.ReceptId
    };
}



    public ReceptDTO GetReceptById(int id)
    {
        var recept = _receptRepository.GetReceptById(id);
        return new ReceptDTO
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };

    }

}
