//domain entity - en given identifierare. Ett id - något slags id
//sen kommer massa andra attribut.
//man måste hitta den i databasen
//skillnad på entitet och value object - det senare har inte id. tex röd, eller grön. entity har id. 

namespace ReceptBank.Domain;

public interface IReceptRepo
{
    //class ReceptBank.Domain.Recept
    //Recept va??? fel skit skit Måste ha ett domain objekt(?)
    Recept GetReceptById(int id);
}
