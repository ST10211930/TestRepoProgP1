using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgPoePart1
{
    class Recipe
    {
        private List<Ingredients> ingredients = new List<Ingredients>();
        private List<string> steps = new List<string>();
        private string recipeName;

        public void AddIngredient(string name, double quantity, string unit)
        {
            ingredients.Add(new Ingredients { Name = name, Quantity = quantity, Unit = unit });
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public void DisplayRecipe()
        {

            Console.WriteLine($"Recipe Name: {recipeName}\n");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            Console.Clear();
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetScaling()
        {
            Console.Clear();
            // Implement logic to reset quantities to original values
        }

        public void ClearRecipe()
        {
            Console.Clear();
            ingredients.Clear();
            steps.Clear();
            recipeName = null;
        }

        public void SetRecipeName(string name)
        {
            recipeName = name;
        }


    }
}
