using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Model
{
    public class GameService
    {
        GuessGame guessGame = new GuessGame();

        public int NewGame()
        {
            Random random = new Random();

            guessGame.SecretNumber = random.Next(1, 101);

            return guessGame.SecretNumber;
        }

        public GuessGame CheckError(int guess)
        {

            if (guess > 100)
            {
                guessGame.ErrorMessage = "Input too high";
                guessGame.Error = true;
            }
            else if (guess < 1)
            {
                guessGame.ErrorMessage = "Input too low";
                guessGame.Error = true;
            }

            guessGame.Guess = guess;
            return guessGame;

        }

    }
}
