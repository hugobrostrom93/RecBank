using System;
using System.Collections.Generic;
using ReceptBank.Domain;

namespace ReceptBank.ApplicationServices
{
    public class ReceptService : IReceptService
    {
        private readonly IReceptRepo _receptRepository;

        public ReceptService(IReceptRepo receptRepository)
        {
            _receptRepository = receptRepository;
        }

        public List<ReceptDTO> GetRecepts()
        {
            var recepts = _receptRepository.GetRecepts();
            var receptDTOs = new List<ReceptDTO>();

            foreach (var recept in recepts)
            {
                var receptDTO = new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId);
                receptDTOs.Add(receptDTO);
            }

            return receptDTOs;
        }

        public ReceptDTO Edit(int id, ReceptDTO updatedRecept)
        {
            var recept = _receptRepository.GetReceptById(id);
            
            // Update properties of the 'recept' object based on 'updatedRecept'
            
            _receptRepository.Edit(recept); // Call the method to save changes
            
            return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId);
        }

        public ReceptDTO Remove(int id)
        {
            var recept = _receptRepository.GetReceptById(id);
            _receptRepository.Remove(id); // Call the method to remove the recipe
            
            return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId);
        }

        public ReceptDTO Create(ReceptDTO newRecept)
        {
            var addedRecipe = _receptRepository.Add(newRecept.Name, newRecept.Ingredients);
            
            return new ReceptDTO(newRecept.Name, newRecept.Ingredients, newRecept.ReceptId)
            {
                Name = addedRecipe.Name,
                Ingredients = addedRecipe.Ingredients,
                ReceptId = addedRecipe.ReceptId
            };
        }

        public ReceptDTO GetReceptById(int id)
        {
            var recept = _receptRepository.GetReceptById(id);
            
            return new ReceptDTO(recept.Name, recept.Ingredients, recept.ReceptId);
        }
    }
}