//domain entity - en given identifierare. Ett id - något slags id
//sen kommer massa andra attribut.
//man måste hitta den i databasen
//skillnad på entitet och value object - det senare har inte id. tex röd, eller grön. entity har id. 

namespace ReceptBank.Domain;

public interface IReceptRepo
{
    Recept GetReceptById(int id);

    Recept Edit(Recept updatedRecept);

    List<Recept> GetRecepts();

    void Remove(int id);

    Recept Create(Recept newRecept);

    Recept Add(string name, string ingredients);
}
