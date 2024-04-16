using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgPoePart1
{
    class Recipe
    {
        //global lists
        private List<Ingredients> ingredients = new List<Ingredients>(); //list holds all the ingredients required for a recipe
        private List<string> steps = new List<string>(); //list stores the steps involved in making the recipe

        //global variable
        private string recipeName; //private string variable used to store the name of the recipe

        // this public method  allows other parts of the program to add a new ingredient to the recipe
        // parameters: the name of the ingredient, its quantity, and the unit of measurement
        public void AddIngredient(string name, double quantity, string unit)
        {
            //adds a new 'Ingredients' object to the 'ingredients' list with specified name, quantity, and unit
            //also initializes 'OriginalQuantity' with the same 'quantity' value.
            ingredients.Add(new Ingredients { Name = name, Quantity = quantity, OriginalQuantity = quantity, Unit = unit });
        }

        //adds a new cooking step to the 'steps' list.
        public void AddStep(string step)
        {
            steps.Add(step);
        }


        public void DisplayRecipe()
        {
            //displays the current recipe information
            Console.WriteLine($"Recipe Name: {recipeName}\n");

            //lists all ingredients with their quantities, units, and names
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            //lists all cooking steps in order
            //each step starts with its sequence number
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // This method is used when adjusting the size of the recipe (e.g., doubling or halving).
        public void ScaleRecipe(double factor)
        {
            Console.Clear();

            //iterates through each ingredient in the recipe's ingredient list
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor; //multiplies the current quantity of each ingredient by the scaling factor
            }
        }

        //resets the quantities of all ingredients in the recipe to their original values
        public void ResetScaling()
        {
            Console.Clear();

            // Iterates through each ingredient in the list of ingredients
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity; //sets the quantity of each ingredient back to its original value
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Scaling has been reset!"); //outputs a message when scaling has been successfully reset
        }

        //clears all the data 
        public void ClearRecipe()
        {
            ingredients.Clear(); //removes all entries from the ingredients list
            steps.Clear();       //removes all entries from the steps list
            recipeName = null;   //resets the recipe name to null, showing that no recipe is currently set
        }

        //sets the name of the recipe
        public void SetRecipeName(string name)
        {
            recipeName = name; //assigns the provided name to the recipeName property
        }


    }
}
