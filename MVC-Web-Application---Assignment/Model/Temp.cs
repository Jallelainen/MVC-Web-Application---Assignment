using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Model
{
    public class Temp
    {

        public int temperature { get; set; }
        public bool hypo { get; set; }
        public bool fever { get; set; }

        public Temp(int Temperature)
        {
            temperature = Temperature;
        }
        public Temp(int Temperature, bool Hypo, bool Fever) : this(Temperature)
        {
            hypo = Hypo;
            fever = Fever;
        }

    }
}
