using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace ReceptBank.Controllers;
public class ReceptController : Controller
{
public IActionResult Recept ()
{
return View();
}
public IActionResult Sök ()

{
return View();
}

public IActionResult ReceptJson ()

{
return View();
}

}