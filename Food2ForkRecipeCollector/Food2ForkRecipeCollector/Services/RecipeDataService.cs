using Food2ForkRecipeCollector.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Food2ForkRecipeCollector.Services
{
    public class RecipeDataService : IRecipeDataService
    {
        private readonly string _filePath;
        private readonly string _folderName = "Food2ForkRecipeCollector";
        private readonly string _fileName = "recipes.json";
        private readonly string _pageBaseFileName = "recipespage";

        public RecipeDataService()
        {
            // Get the path to the app data
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Get the folder of the application in roaming
            string appFolder = Path.Combine(appDataPath, _folderName);
            // Get the data folder inside the app
            string dataFolder = Path.Combine(appFolder, "data");

            // Check if the data folder exists
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Define the path to the json file
            _filePath = Path.Combine(dataFolder, _fileName);

            // Ensure the json file exists
            InitializeFile();
        }

        private void InitializeFile()
        {
            // Check if the file exists
            if (!File.Exists(_filePath))
            {
                // Creates a json file and adds the structure
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(new Recipes()));
            }

            // For debug purposes
            //Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName));
        }

        public Recipes LoadRecipes()
        {
            // Read and deserialise the JSON file
            string fileContent = File.ReadAllText(_filePath);

            return JsonConvert.DeserializeObject<Recipes>(fileContent);
        }

        public void SaveRecipes(Recipes recipes)
        {
            // Serialize and write the lis of tasks to the json file
            string json = JsonConvert.SerializeObject(recipes, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void AddRecipe(Results recipe)
        {
            // Generating a new Id number
            recipe.Pk = GenerateNewRecipeId();

            var recipes = LoadRecipes();
            recipes.Results.Add(recipe);
            SaveRecipes(recipes);
        }

        public void UpdateRecipe(Results recipe)
        {
            var recipes = LoadRecipes();
            var recipeIndex = recipes.Results.FindIndex(r => r.Pk == recipe.Pk);

            if (recipeIndex != -1)
            {
                recipes.Results[recipeIndex] = recipe;
                SaveRecipes(recipes);
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            var recipes = LoadRecipes();

            recipes.Results.RemoveAll(r => r.Pk == recipeId);
            SaveRecipes(recipes);
        }

        // Generate a new task id by getting the max ID and addin 1 to it
        public int GenerateNewRecipeId()
        {
            var recipes = LoadRecipes();

            if (!recipes.Results.Any())
            {
                return 1;
            }

            int maxId = recipes.Results.Max(recipe => recipe.Pk);

            return maxId + 1;
        }
    }
}
