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
        return new Recept("Kladdkaka", "smör"); // Mock implementation
    }
}

