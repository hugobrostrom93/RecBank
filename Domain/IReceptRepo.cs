//domain entity - en given identifierare. Ett id - något slags id
//sen kommer massa andra attribut.
//man måste hitta den i databasen
//skillnad på entitet och value object - det senare har inte id. tex röd, eller grön. entity har id. 
using ReceptBank.ApplicationServices;

namespace ReceptBank.Domain;

public interface IReceptRepo
{
    ReceptDTO GetReceptById(int id);

    Recept Edit(ReceptDTO updatedRecept);

    List<Recept> GetRecepts();
}
