//controller communicerar med viewModel, och view kommunicerar med viewModel. Model binding. In every action method it calls view
//dataflow is between controller and model
//controller knows about the view and model
//view knows nothing - view is databarer. 


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
            var recepts = new List<ReceptViewModel>();
            ReceptDTO[] receptDTO = new ReceptDTO[10];
            ReceptViewModel[] recept = new ReceptViewModel[10];
            for (int i = 1; i < 4; i++) {
            // Get the person from the service
            receptDTO[i] = _receptService.GetRecepts();
            recept[i] = new ReceptViewModel
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