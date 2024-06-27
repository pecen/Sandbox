using Food2ForkRecipeCollector.Models;
using Food2ForkRecipeCollector.Services;
using RestSharp;
using System.Runtime.InteropServices;
using static System.Console;

namespace Food2ForkRecipeCollector
{
    internal class Program
    {
        private const string _baseUri = "https://food2fork.ca/api/recipe/search/";

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ShowMenu();

                    var choice = GetUserChoice();

                    // Convert 1-based menu choice to 0-based index
                    var choiceIndex = (int)choice;

                    // Check if choice is within the valid range
                    if (choiceIndex >= 0 && choiceIndex < Enum
                            .GetValues(typeof(MenuChoices))
                            .Length) // Check against all menu items
                    {
                        switch (choice)
                        {
                            case MenuChoices.CreateJsonFile:
                                CreateJson();
                                break;
                            case MenuChoices.GetAllRecipes:
                                GetAllRecipes();
                                break;
                            case MenuChoices.ImportRecipesFromPage:
                                ImportPagedRecipes();
                                break;
                            case MenuChoices.ImportRecipes:
                                ImportRecipes();
                                break;
                            case MenuChoices.ImportIngredientsRecipes:
                                ImportIngredientsRecipes();
                                break;
                            case MenuChoices.Exit:
                                Write(
                                    "Are you sure you want to exit the application? (Y/N): "
                                );
                                var confirmation = ReadLine()
                                    .ToUpper()[0];
                                WriteLine();
                                if (confirmation == 'Y')
                                {
                                    WriteLine("Exiting the application...");
                                    return; // Exit the Main method
                                }

                                Clear();
                                continue;

                            default:
                                throw new Exception("Wrong menu choice!");
                                //WriteLine(
                                //    "Invalid choice. Please try again."
                                //);
                                //break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLine();
                    WriteLine("There was an error: ");
                    while (ex != null)
                    {
                        WriteLine(ex.Message);
                        ex = ex.InnerException;
                    }

                    WriteLine();
                    WriteLine("Press <ENTER> to return to menu.");
                    ReadLine();
                }
            }
        }

        private static void ImportIngredientsRecipes()
        {
            WriteLine("Type the ingredients to use with a space between them: ");
            string ingredients = ReadLine();

            var recipes = DownloadRecipes(1, ingredients);
        }

        private static void ImportRecipes()
        {
            var recipeService = new RecipeDataService();
            var recipes = DownloadRecipes();
            var pages = recipes.Count;
            var recipesPerPage = 30;
            var loops = pages % recipesPerPage == 0 ? pages / recipesPerPage : pages / recipesPerPage + 1;

            for (var i = 2; i <= loops; i++)
            {
                var tmpRecipes = DownloadRecipes(i);

                recipes.Results.AddRange(tmpRecipes.Results);
            }

            recipeService.SaveRecipes(recipes);
        }

        private static Recipes DownloadRecipes(int page = 1, string ingredients = "")
        {
            var client = new RestDataService(_baseUri);

            var request = new RestRequest($"/?page={page}&query={ingredients}", Method.Get);
            request.AddHeader("Authorization", "Token 9c8b06d329136da358c2d00e76946b0111ce2c48");

            return client.Execute<Recipes>(request);
        }

        private static void GetAllRecipes()
        {
            var client = new RecipeDataService();

            var recipes = client.LoadRecipes();
            List<Results> recipesWithInstructions = recipes.Results
                .Where(r => r.Cooking_Instructions != null)
                .ToList();
        }

        private static void ImportPagedRecipes()
        {
            Write("Type the recipes page number: ");
            var page = ReadLine();

            var recipes = DownloadRecipes(int.Parse(page));
        }

        private static void CreateJson()
        {
            WriteLine("Create Json goes here");
        }

        private static MenuChoices GetUserChoice()
        {
            var input = ReadLine();

            return Enum.TryParse(input, out MenuChoices choice)
                ? choice - 1
                : MenuChoices.Unknown;
        }

        private static void ShowMenu()
        {
            //Clear();

            WriteLine("PREREQ:");
            WriteLine("1. Set first req here,");
            WriteLine("2. Set second req here");

            WriteLine("");

            WriteLine("Please choose an action:\n");

            var menuItemNumber = 1;
            foreach (MenuChoices choice in Enum.GetValues(typeof(MenuChoices)))
            {
                if (choice != MenuChoices.Unknown)
                {
                    var description = choice.GetEnumDescription();
                    WriteLine($" {menuItemNumber})      {description}");
                    menuItemNumber++;
                }
            }
        }
    }
}
