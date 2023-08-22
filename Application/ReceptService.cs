

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
        // Get a Person object from the repository
        var recept = _receptRepository.GetRecepts();
        return new List<ReceptDTO>
        {
            Name = recept.Name,
            Ingredients = recept.Ingredients
        };
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
