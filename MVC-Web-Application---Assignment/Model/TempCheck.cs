using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Model
{
    public class TempCheck
    {


        bool fever;
        bool hypo;
        public bool Check(int temp)
        {
            if (temp >= 38)
            {
                fever = true;
                return fever;

            }else if (temp <= 35)
            {
                hypo = true;
                return true;
            }
            else
            {
                hypo = false;
                fever = false;
                return hypo && fever;
            }
        }

    }
}
