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

        //Assuming you have a method in your IReceptService interface to remove a recipe by its ID, 
        //you can call that method from your controller.
        
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var remove = _receptService.Remove(id);
            return View(Recept); // Redirect back to the recipe list
        }
            
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _receptService.Edit(id);
            return View(Recept); // Redirect back to the recipe list
        }
}