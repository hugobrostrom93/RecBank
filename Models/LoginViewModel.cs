//viewModel som tar hand om username och password

using System.ComponentModel.DataAnnotations;
namespace AuthDemo.Models;
public class LoginViewModel
{
[Required]
//required är decoration där det är ett måste att ha med det. 
public string? Username { get; set; }
[Required]
[DataType(DataType.Password)]
public string? Password { get; set; }
}