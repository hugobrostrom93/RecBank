//en form av DTO, den känner inte till något annat än sig självt, 
//specifik roll mellan view och controller. 
//inte bara en modell, en DTO som transporterar data mellan model och controller.
//gjord för datan vi vill presentera utåt
//hej

using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace ReceptBank.Models;
public class ReceptViewModel
{
    
    public int ReceptId {get; set;}

    [Required]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+( [a-zA-ZåäöÅÄÖ]+)*$", ErrorMessage = "Use letters only and only one space between words")]
    public string Name { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-ZåäöÅÄÖ,0-9]+( [a-zA-ZåäöÅÄÖ,0-9]+)*$", ErrorMessage = "Use letters and numbers only and only one space between words")]
    public string Ingredients { get; set; }
}
