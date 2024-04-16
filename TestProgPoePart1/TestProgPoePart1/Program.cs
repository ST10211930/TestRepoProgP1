using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgPoePart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                DisplayMenu();

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipe.ClearRecipe(); // Clear previous recipe data
                        EnterRecipeDetails(recipe);
                        break;
                    case "2":
                        Console.Clear();
                        recipe.DisplayRecipe();
                        GoBackToMenu();
                        break;
                    case "3":
                        ScaleRecipe(recipe);
                        break;
                    case "4":
                        recipe.ResetScaling();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1: Add a new recipe");
            Console.WriteLine("2: Display a recipe");
            Console.WriteLine("3: Scale recipe");
            Console.WriteLine("4: Reset scaling");
            Console.WriteLine("5: Clear all data");
            Console.WriteLine("6: Exit Program");
        }

        static void EnterRecipeDetails(Recipe recipe)
        {
            Console.Clear();
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            recipe.SetRecipeName(name);

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine("choose from the list of Unit of Measurements below and type it in: \n" +
                 " kg\n" +
                 " g\n" +
                 " mg\n" +
                 " L\n" +
                 " mL\n" +
                 " tablespoon\n" +
                 " teaspoon");
                string unit = Console.ReadLine();

                recipe.AddIngredient(ingredientName, quantity, unit);
            }

            Console.Write("\nEnter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            Console.WriteLine("\nRecipe saved successfully!");
            GoBackToMenu();
        }

        static void ScaleRecipe(Recipe recipe)  //item unit scaling logic
        {
            Console.Clear();
            Console.Write("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
            double factor = double.Parse(Console.ReadLine());
            recipe.ScaleRecipe(factor);
            Console.WriteLine("\nRecipe scaled successfully!");
            GoBackToMenu();
        }

        static void GoBackToMenu() // redirect user to the menu so that the can choose a different option
        {
            Console.WriteLine("\nPress Enter to go back to the menu...");
            Console.ReadLine();
        }
    }
}
