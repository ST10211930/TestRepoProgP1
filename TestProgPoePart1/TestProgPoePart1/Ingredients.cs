using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgPoePart1
{
    class Ingredients
    {
        //public property 'name' to get or set the name of the ingredient 
        //name is accessed and changed in the rest of the app
        public string Name { get; set; }
        //public property 'quantity' to get or set the quanitity of the ingredient needed
        //quantity can be scaled down or up
        public double Quantity { get; set; }
        //public property 'Originalquantity' to store the original quanitity of the ingredient 
        //resets the quantity to its original value after scaling
        public double OriginalQuantity { get; set; }
        //public property 'unit' to get or set the unit of measurement for the ingredient
        //describes the units (g, kg, teaspons, etc.)
        public string Unit {  get; set; }
    }
}
