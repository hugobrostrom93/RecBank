namespace ReceptBank.Infrastructure;

using ReceptBank.Domain;


public class ReceptRepo : IReceptRepo
{
    public Recept GetReceptById(int id)
    {
        //TODO skriv rätt
        return new Recept("Kladdkaka", "smör"); // Mock implementation
    }
}

