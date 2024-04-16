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
                        GoBackToMenu();
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

        static int ReadInt(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number))
                    return number;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static double ReadDouble(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static void EnterRecipeDetails(Recipe recipe)
        {
            Console.Clear();
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            recipe.SetRecipeName(name);

            int ingredientCount = ReadInt("Enter the number of ingredients: ");
            string[] units = { "kg", "g", "mg", "L", "mL", "tablespoon", "teaspoon" };

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                double quantity = ReadDouble("Quantity: ");
                Console.WriteLine("Choose from the list of Unit of Measurements below:");
                for (int j = 0; j < units.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {units[j]}");
                }

                //validation
                int unitChoice = -1;
                while (unitChoice < 0 || unitChoice >= units.Length)
                {
                    unitChoice = ReadInt("Enter your choice: ") - 1;
                    if (unitChoice < 0 || unitChoice >= units.Length)
                    {
                        Console.WriteLine("Invalid choice, please select a valid unit from the list.");
                    }
                }
                string unit = units[unitChoice];

                recipe.AddIngredient(ingredientName, quantity, unit);
            }

            int stepCount = ReadInt("\nEnter the number of steps: ");
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            Console.WriteLine("\nRecipe saved successfully!");
            GoBackToMenu();
        }

        static void ScaleRecipe(Recipe recipe)
        {
            Console.Clear();
            double factor = 0;
            while (factor != 0.5 && factor != 2 && factor != 3)
            {
                factor = ReadDouble("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                if (factor != 0.5 && factor != 2 && factor != 3)
                {
                    Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                }
            }
            recipe.ScaleRecipe(factor);
            Console.WriteLine("\nRecipe scaled successfully!");
            recipe.DisplayRecipe();
            GoBackToMenu();
        }

        static void GoBackToMenu() // redirect user to the menu so that the can choose a different option
        {
            Console.WriteLine("\nPress Enter to go back to the menu...");
            Console.ReadLine();
        }
    }
}
