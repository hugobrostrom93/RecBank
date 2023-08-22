

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
                Ingredients = recept.Ingredients
            };

            receptDTOs.Add(receptDTO);
        }

        return receptDTOs;
    }



    public ReceptDTO Remove(int Id)
    {
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };
      
    }
    public ReceptDTO Edit(int Id)
    {
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO
        {
            // Recipes.Edit(Recept);
            // _context.SaveChanges();
        };
    }

    public ReceptDTO Create()
    {
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };
      
    }
    public ReceptDTO GetReceptById(int Id)
    {
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO
        {
            // Recipes.Remove(Recept);
            // _context.SaveChanges();
        };
      
    }

}
