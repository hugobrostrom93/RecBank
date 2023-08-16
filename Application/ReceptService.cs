namespace ReceptBank.ApplicationServices;
using ReceptBank.Domain;

public class ReceptService : IReceptService
{
    private readonly IReceptRepo _receptRepository;

    public ReceptService(IReceptRepo receptRepository)
    {
        _receptRepository = receptRepository;
    }

    public ReceptDTO GetRecept()
    {
        // Get a Person object from the repository
        var recept = _receptRepository.GetReceptById(1);
        return new ReceptDTO
        {
            Name = recept.Name,
            Ingredients = recept.Ingredients
        };
    }
}
