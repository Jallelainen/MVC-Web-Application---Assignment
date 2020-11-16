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

        public GuessGame Check(int guess, int secretNum)
        {
            //Check error
            if (guess < 1 || guess > 100)
            {
                guessGame.ErrorMessage = "Input outside of 1 to 100 range";
                guessGame.Error = true;
            }
            
            //Check guess
            if (guess < secretNum)
            {
                guessGame.GameMessage = "Your guess was lower than the secret number";
            }
            else if (guess > secretNum)
            {
                guessGame.GameMessage = "Your guess was higher than the secret number";
            }
            else
            {
                guessGame.GameMessage = "Correct! That was the right number!";
                guessGame.Win = true;
            }
            

            guessGame.Guess = guess;
            return guessGame;

        }

    }
}
