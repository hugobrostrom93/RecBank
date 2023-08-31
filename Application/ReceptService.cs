

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
            var receptDTO = new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId)
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
        var recept = _receptRepository.GetReceptById(id);

        // Update properties of the originalRecept based on updatedRecept

        // Call a method on the repository to save changes
        
        //_receptRepository.Edit(originalRecept);

        // Return a ReceptDTO representing the updated recipe
        return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId)
        {
            Name = recept.Name,
            Ingredients = recept.Ingredients,
            ReceptId = recept.ReceptId
        };
    }


    public ReceptDTO Remove(int id)
    {
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId)
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };

    }
    //implement logic for editing recept 

    public ReceptDTO Create()
    {
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId)
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };

    }
    public ReceptDTO GetReceptById(int id)
    {
        var recept = _receptRepository.GetReceptById(id);
        return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId)
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };

    }

}
