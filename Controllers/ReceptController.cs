using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ReceptBank.ApplicationServices;
using ReceptBank.Models;

namespace ReceptBank.Controllers;

public class ReceptController : Controller

    {

        private readonly IReceptService _receptService;

        public ReceptController(IReceptService receptService)
        {
            _receptService = receptService;
        }

        public IActionResult Recept()
        {
            var recepts = new List<ReceptModel>();
            ReceptDTO[] receptDTO = new ReceptDTO[10];
            ReceptModel[] recept = new ReceptModel[10];
            for (int i = 1; i < 4; i++) {
            // Get the person from the service
            receptDTO[i] = _receptService.GetRecept(i);
            recept[i] = new ReceptModel
            {
                Name = receptDTO[i].Name,
               // Ingredients = receptDTO[i].Ingredients
            };
            recepts.Add(recept[i]);
            }
            
            return View(recepts);
        }
}