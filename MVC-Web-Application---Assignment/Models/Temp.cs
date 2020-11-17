using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Models
{
    public class Temp
    {

        public int temperature { get; set; }
        public bool hypo 
        { 
            get
            {
                return temperature < 35 ? true : false;
            } 
        }
        public bool fever 
        {
            get
            {
                return temperature > 37 ? true : false;
            } 

        }

        public Temp()
        {
            
        }

        public Temp(int Temperature)
        {
            temperature = Temperature;
        }

    }
}
