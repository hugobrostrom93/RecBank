//controller communicerar med viewModel, och view kommunicerar med viewModel. Model binding. In every action method it calls view
//dataflow is between controller and model
//controller knows about the view and model
//view knows nothing - view is databarer. 


using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ReceptBank.ApplicationServices;
using ReceptBank.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authorization;

namespace ReceptBank.Controllers;

[Authorize] // This attribute ensures that only authenticated users can access this action.

public class ReceptController : Controller

{
    private readonly IReceptService _receptService;

    public ReceptController(IReceptService receptService)
    {
        _receptService = receptService;
    }

    public IActionResult Recept()
    {
        List<ReceptDTO> receptDTOs = _receptService.GetRecepts();
        List<ReceptViewModel> recepts = new List<ReceptViewModel>();

        foreach (var receptDTO in receptDTOs)
        {
            var item = new ReceptViewModel
            {
                ReceptId = receptDTO.ReceptId,
                Name = receptDTO.Name,
                Ingredients = receptDTO.Ingredients
            };
            recepts.Add(item);
        }

        return View(recepts);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ReceptDTO receptToEdit = _receptService.GetReceptById(id);

        if (receptToEdit == null)
        {
            return NotFound(); // Handle scenario where recipe is not found
        }

        // Create a ReceptViewModel and populate it with data from the ReceptDTO
        ReceptViewModel editRecept = new ReceptViewModel
        {
            ReceptId = receptToEdit.ReceptId,
            Name = receptToEdit.Name,
            Ingredients = receptToEdit.Ingredients
            // Populate other properties as needed
        };

        return View(editRecept);
    }

}


// [HttpPost]
// public IActionResult Ingredienser(int id)
// {
//     List<ReceptDTO> receptDTOs = _receptService.GetReceptById(id);
//     List<ReceptViewModel> recepts = new List<ReceptViewModel>();

//     foreach (var receptDTO in receptDTOs)
//     {
//         var item = new ReceptViewModel
//         {
//             id = receptDTO.ReceptId,
//             Ingredients = receptDTO.Ingredients,
//             var edit = _receptService.Edit(id)
//         };
//         recepts.Add(item);
//     }

//     //return View(recepts);
//     //RedirectToAction(Recept);
// }



// [HttpPost]
// public IActionResult Remove(int id)
// {
//     var remove = _receptService.Remove(id);
//     return View(Recept); // Redirect back to the recipe list
// }

