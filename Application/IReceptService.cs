namespace ReceptBank.ApplicationServices;

public interface IReceptService
{
    ReceptDTO GetRecept(int x);

    ReceptDTO Remove(int Id);

    ReceptDTO Edit(int Id);
}

//osäker men tror att dessa är constructors? 
//Som deklarerar metoder. Använder DTO (data transfer object) för att få datan från json till c#