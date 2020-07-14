using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    [Serializable]
    public class Gender
    {
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Can't be empty!", nameof(name));    // cheching for entering parammeters, then =
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
