namespace ReceptBank.Domain;

public interface IReceptRepo
{
    //class ReceptBank.Domain.Recept
    //Recept va??? fel skit skit Måste ha ett domain objekt(?)
    Recept GetReceptById(int id);
}
