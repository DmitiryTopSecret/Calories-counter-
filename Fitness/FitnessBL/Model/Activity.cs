using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    [Serializable]
    public class Activity
    {
        
        public string Name { get; }

        public double CalloriesPerMinute { get; }

        public Activity(string name, double calloriesPerMinute)
        {
            // TODO: Verification
            Name = name;
            CalloriesPerMinute = calloriesPerMinute;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
