using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace ReceptBank.Models;
public class Recept
{
    
    public int ReceptId {get; set;}

    [Required]
    [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Use letters only and only one space between names, please")]
    public string Name {get; set;}

    [Required]
    [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Use letters only and only one space between names, please")]
    public string Ingredients {get; set;}
}