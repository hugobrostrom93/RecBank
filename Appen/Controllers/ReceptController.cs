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
using ReceptBank.Infrastructure;
using Microsoft.VisualBasic;

namespace ReceptBank.Controllers;

//[Authorize] // This attribute ensures that only authenticated users can access this action.

public class ReceptController : Controller

{
    private readonly IReceptService _receptService;

    public ReceptController(IReceptService receptService)
    {
        _receptService = receptService;
    }

    [Authorize]
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

    [HttpPost]
    public IActionResult SubmitEdit(int id, string name, string ingredients)
    {

        var input = new ReceptDTO(name, ingredients, id);
        var returnItem = new ReceptRepoJson();
        returnItem.Edit(input);
        return RedirectToAction("Edited");
    }

    public ActionResult Edited()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Remove(int id)
    {
        // Call the service to remove the recipe
        _receptService.Remove(id);

        // Redirect back to the recipe list view
        return View("Remove");
    }

    [HttpGet]
    public IActionResult Create()
    {
        // Create an empty ReceptViewModel for the creation form
        var newReceptViewModel = new ReceptViewModel();

        return View(newReceptViewModel);
    }

    [HttpPost]
    public IActionResult Create(ReceptViewModel newReceptViewModel)
    {
        if (ModelState.IsValid)
        {
            // Map the data from the ViewModel to a ReceptDTO
            var newReceptDTO = new ReceptDTO(newReceptViewModel.Name, newReceptViewModel.Ingredients, newReceptViewModel.ReceptId)
            {
                Name = newReceptViewModel.Name,
                Ingredients = newReceptViewModel.Ingredients
            };

            // Call the service to create a new recipe
            _receptService.Create(newReceptDTO);

            // Redirect back to the recipe list view after creation
            return RedirectToAction("Recept");
        }

        // If the model state is not valid, return back to the creation form with validation errors
        return View(newReceptViewModel);
    }

    // [HttpPost]
    // public IActionResult Ingredienser(int id)
    // {
    //     ReceptDTO receptDTO = _receptService.GetReceptById(id);
    //     ReceptViewModel information = new ReceptViewModel();

    //     return View(information);
    // }
    [HttpPost]
    public IActionResult Ingredienser(int id)
    {
        ReceptDTO receptDTO = _receptService.GetReceptById(id);
        ReceptViewModel information = new ReceptViewModel
        {
            ReceptId = receptDTO.ReceptId,
            Name = receptDTO.Name,
            Ingredients = receptDTO.Ingredients
        };

        return View(information);
    }

}



