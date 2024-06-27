using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food2ForkRecipeCollector
{
    public enum MenuChoices
    {
        [Description("Create Json File")]
        CreateJsonFile,
        [Description("Get All Recipes")]
        GetAllRecipes,
        [Description("Get Recipe Page")]
        ImportRecipesFromPage,
        [Description("Get Recipes based on ingredients")]
        ImportIngredientsRecipes,
        [Description("Import Recipes from Food2Fork.com")]
        ImportRecipes,
        Exit,
        Unknown
    }
}
