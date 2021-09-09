using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NxCore.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NxCore.API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    [Authorize]

    public class RecipesController : ControllerBase
    {
        [HttpPost()]
        [Authorize(Roles = "PayingUser")] // matches  new Claim("role", "PayingUser") // this will validate token and check if PayingUser
        public async Task<IActionResult> CreateRecipe(RecipeForCreation recipeForCreation )
        {
            // we get owner id from token bettter than from header etc
            var ownerId = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            if(ownerId != null)
            {
                // 1 st map Recipe For Creation to Recipe entity and use add onwerId to its OwnerId field
                // 2 call repository etc
            }
            // todo
            return null;
        }
    }
}
