using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double  Carbohydrates { get; set; }

        // Calroies of 100 gramm in prioduct
        public double Callories { get; }


        public Food(string name) : this(name, 0,0,0,0) { }
        public Food (string name, double callories, double proteins, double fats, double carbohydates)
        {
            // TODO: Verification
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydates / 100.0;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
