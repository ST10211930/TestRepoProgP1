using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace TestProgPoePart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create an instance of the Recipe class to manage recipe data
            Recipe recipe = new Recipe();

            //while loop to keep app running until the user decides to exit
            while (true)
            {
                //display the main menu
                DisplayMenu();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter your choice: ");

                //User input
                string choice = Console.ReadLine();

                //switch statement for user choices
                switch (choice)
                {
                    case "1":
                        recipe.ClearRecipe(); // clear previous recipe data
                        EnterRecipeDetails(recipe); //user to enter details for a new recipe
                        break;
                    case "2":
                        Console.Clear(); //clear console for a clean display
                        recipe.DisplayRecipe();
                        GoBackToMenu(); //prompt to return to the menu
                        break;
                    case "3":
                        ScaleRecipe(recipe); //a method to scale the recipe quantities 
                        break;
                    case "4":
                        recipe.ResetScaling(); //reset scaling applied to the recipe to original
                        GoBackToMenu();
                        break;
                    case "5":
                        Console.Clear();
                        //confirm if user wants to clear recipe data
                        if (ConfirmClearData())
                        {
                            //clear the recipe data
                            recipe.ClearRecipe();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Data Cleared Successfully!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Data clear canceled.");
                        }
                        GoBackToMenu();
                        break;
                    case "6":
                        Environment.Exit(0); //exit program 
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        GoBackToMenu();
                        break;
                }
            }//while loop ends
        }//main class ends

        static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ***** SANELE'S RECIPE APP****** "); //application name
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1: Add a new recipe");
            Console.WriteLine("2: Display a recipe");
            Console.WriteLine("3: Scale recipe");
            Console.WriteLine("4: Reset scaling");
            Console.WriteLine("5: Clear all data");
            Console.WriteLine("6: Exit Program");
        }

        static int ReadInt(string prompt)
        {
            //declare variable
            int number;

            //while loop to prompt user until there is avalid input 
            while (true)
            {
                //display prompt message tp user for the corect input
                Console.Write(prompt);

                //converting user input from string to int
                if (int.TryParse(Console.ReadLine(), out number)) //assigns the parsed value to 'number' and returns true
                    //if the input is valid, return parsed value 
                    return number;

                //if parsing fails, show message
                Console.ForegroundColor = ConsoleColor.Red; //text changed to red to indicate an error message 
                Console.WriteLine("Invalid input. Please enter a valid number."); //error mesage

                //after displaying the message, the loop will start over, to prompt the user
            }
        }

        static double ReadDouble(string prompt) //method to read a double from the user
        {
            //declare variable 
            double number;
            //while loop to prompt user until a double is entered
            while (true)
            {
                //ask user for input 
                Console.Write(prompt);

                //converts user input from a string to a double
                if (double.TryParse(Console.ReadLine(), out number)) //converts string to double, and stores it in 'number'
                    //if the input is valid, return parsed value 
                    return number;

                //if input is invalid, display error message 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            
                //after error message, the loop carry's on, asking the user again until they input a valid double input
            }
        }

        //method that asks the user for confirmation 
        static bool ConfirmClearData()
        {
            while (true)
            {
                //display a confirmation message to the user to ensure they intend to clear all data
                Console.WriteLine("Are you sure you want to clear all data?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                //prompt user to enter their choice
                Console.Write("Enter your choice (1 for Yes, 2 for No): ");
                //read users input as a string
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //if the user enters '1', they confirm they want to clear all data
                        return true; //return true to indicate this choice
                    case "2": //if the user enters '2', they do not want to clear the data
                        return false;  //return false to indicate this choice
                    default:
                        //if the user enters any other value, tell them of their invalid choice
                        Console.WriteLine("Invalid choice. Please enter 1 for Yes or 2 for No.");
                        //loop continues until a valid choice is entered
                        break;
                }
            }
        }

        //method to enter and save recipe details, taking a 'Recipe' object as a parameter to add details to
        static void EnterRecipeDetails(Recipe recipe)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            //prompt user to enter the name of recipe
            Console.Write("Enter recipe name: ");
            //read  recipe name from user input
            string name = Console.ReadLine();
            //set the recipe name in the recipe object
            recipe.SetRecipeName(name);

            //prompt the user to enter the number of ingredients 
            int ingredientCount = ReadInt("Enter the number of ingredients: ");
            //define a list of possible units of measurement 
            string[] units = { "kg", "g", "mg", "L", "mL", "tablespoon", "teaspoon" };

            //for loop, loops through each ingredient the user wants to add, based on the count provide
            for (int i = 0; i < ingredientCount; i++)
            {
                //display info about which ingredient number is being entered.
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                //read ingredient name from user input
                string ingredientName = Console.ReadLine();

                //prompt and read the quantity of the ingredient as a double
                double quantity = ReadDouble("Quantity: ");

                //list the units for the user to choose from
                Console.WriteLine("Choose from the list of Unit of Measurements below:");
                for (int j = 0; j < units.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {units[j]}");
                }

                //initialize unit choice outside of a valid range to start the loop
                int unitChoice = -1;
                while (unitChoice < 0 || unitChoice >= units.Length)
                {
                    //prompt user to enter their choice based on list provided
                    unitChoice = ReadInt("Enter your choice: ") - 1;
                    if (unitChoice < 0 || unitChoice >= units.Length)
                    {
                        //inform the user of an invalid choice and repeat the prompt 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice, please select a valid unit from the list.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                //get the selected unit using the validated index
                string unit = units[unitChoice];

                //add the ingredient to the recipe object
                recipe.AddIngredient(ingredientName, quantity, unit);
            }

            //prompt the user for the number of steps in the recipe
            int stepCount = ReadInt("\nEnter the number of steps: ");
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                //read each step from the user and add it to the recipe
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            //inform the user that the recipe has been saved successfully
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe saved successfully!");
            //return to main menu
            GoBackToMenu();
        }

        //method for scaling the recipe ingredients by a stated factor
        //it takes a 'Recipe' object as a parameter.
        static void ScaleRecipe(Recipe recipe)
        {
            Console.Clear();
            //initialize the scaling factor variable
            double factor = 0;

            //while loop to validate the scaling factor entered by the user
            //it only accepts 0.5, 2, or 3
            while (factor != 0.5 && factor != 2 && factor != 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //prompt the user to enter a scaling factor and read their input
                factor = ReadDouble("Enter the scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                //check if the entered factor is one of the allowed values
                //if not, prompt the user again
                if (factor != 0.5 && factor != 2 && factor != 3)
                {
                    //console text color set to red for error messages 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                }
            }

            //if a valid factor is entered, call the ScaleRecipe method on the recipe object to scale the ingredients
            recipe.ScaleRecipe(factor);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe scaled successfully!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            //display the scaled recipe to the user
            recipe.DisplayRecipe();
            
            GoBackToMenu();
        }

        //method made to pause the program and guide the user back to the main menu
        static void GoBackToMenu()
        {
            // console text color is yellow for better visibility and consistency with the app color scheme
            Console.ForegroundColor = ConsoleColor.Yellow;

            //output message, prompting the user to press the Enter key to proceed
            Console.WriteLine("\nPress Enter to go back to the menu...");
            Console.ReadLine();
        }
    }
}
