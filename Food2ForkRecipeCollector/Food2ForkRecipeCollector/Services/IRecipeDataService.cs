using Food2ForkRecipeCollector.Models;

namespace Food2ForkRecipeCollector.Services
{
    public interface IRecipeDataService
    {
        void AddRecipe(Results recipe);
        void DeleteRecipe(int recipeId);
        Recipes LoadRecipes();
        void SaveRecipes(Recipes recipes);
        void UpdateRecipe(Results recipe);
    }
}