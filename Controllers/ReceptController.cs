//controller communicerar med viewModel, och view kommunicerar med viewModel. Model binding. In every action method it calls view
//dataflow is between controller and model
//controller knows about the view and model
//view knows nothing - view is databarer. 


using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ReceptBank.ApplicationServices;
using ReceptBank.Models;
using Microsoft.AspNetCore.Http.Features;

namespace ReceptBank.Controllers;

public class ReceptController : Controller

    {

        private readonly IReceptService _receptService;

        public ReceptController(IReceptService receptService)
        {
            _receptService = receptService;
        }

        //presentera listan - fungera i loop.
       
       public IActionResult Recept()
        {
            List<ReceptDTO> receptDTOs = _receptService.GetRecepts(); // Assuming _receptService.GetRecepts() returns an array
            List<ReceptViewModel> recepts = new List<ReceptViewModel>();

            foreach (var receptDTO in receptDTOs)
            {
                var item = new ReceptViewModel
                {
                    Name = receptDTO.Name,
                    Ingredients = receptDTO.Ingredients
                };
                recepts.Add(item);
            }

            return View(recepts);
        }
 }

        //Assuming you have a method in your IReceptService interface to remove a recipe by its ID, 
        //you can call that method from your controller.
        
        // [HttpPost]
        // public IActionResult Remove(int id)
        // {
        //     var remove = _receptService.Remove(id);
        //     return View(Recept); // Redirect back to the recipe list
        // }
            
        // [HttpGet]
        // public IActionResult Edit(int id)
        // {
        //     var edit = _receptService.Edit(id);
        //     return View(Recept); // Redirect back to the recipe list
        // }
