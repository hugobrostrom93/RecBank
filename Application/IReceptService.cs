namespace ReceptBank.ApplicationServices;

public interface IReceptService
{
    List<ReceptDTO> GetRecepts();
    //plural - returvärde lista

    ReceptDTO Remove(int id);
    //ngt returvärde som visar successs eller ngt

    ReceptDTO Edit(int id);

    ReceptDTO Create();
    //skapar id

    ReceptDTO GetReceptById(int id);
}

//osäker men tror att dessa är constructors? 
//Som deklarerar metoder. Använder DTO (data transfer object) för att få datan från json till c#
//crud - fem methods , read/getitems, getrecbyid, create/add, delete/remove/purge, update/edit