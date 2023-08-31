namespace ReceptBank.ApplicationServices;

public class ReceptDTO //: IEnumerable<ReceptDTO>
{
    public ReceptDTO(string name, string ingredients, int receptId)
    {
        Name = name;
        Ingredients = ingredients;
        ReceptId = receptId;
    }

    public int ReceptId {get; set; }
    public string? Name { get; set; }
    public string Ingredients { get; set; }
}

//vilken information vi vill lämna ut
//skillnad på controller service  
//controller får från utsidan. URL, användar interaktion
//lämpat för presentation 