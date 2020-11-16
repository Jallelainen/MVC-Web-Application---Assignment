using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Model
{
    public class GuessGame
    {
        public int Guess { get; set; }
        public int SecretNumber { get; set; }
        public bool Error { get; set; }
        public bool Win { get; set; }
        public string ErrorMessage { get; set; }
        public string GameMessage { get; set; }
    }
}
