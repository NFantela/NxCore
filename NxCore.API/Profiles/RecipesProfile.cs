using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NxCore.API.Profiles
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        {
            CreateMap<Entities.Recipe, Models.Recipes.RecipeForCreation>();
        }
    }
}
