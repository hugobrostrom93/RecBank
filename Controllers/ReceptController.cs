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
            // Get the person from the service
            var receptDTO = _receptService.GetRecept();
            var recept = new ReceptModel
            {
                Name = receptDTO.Name,
                Ingredients = receptDTO.Ingredients
            };

            var recepts = new List<ReceptModel>
            {
                recept
            };
            
            return View(recepts);
        }
}
