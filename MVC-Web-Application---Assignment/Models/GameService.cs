using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Models
{
    public class GameService
    {
        GuessGame guessGame = new GuessGame();
        Highscore highscore = new Highscore();

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

        public int Count(int counter)
        {
            counter++;
            return counter;
        }


        public Highscore CheckHigh(int playerscore, int high1, int high2, int high3)
        {
            highscore.High1 = high1;
            highscore.High2 = high2;
            highscore.High3 = high3;

            if (high1 > 0 && playerscore < high1 || high1 == 0 && playerscore > high1) 
            {
                highscore.High3 = highscore.High2;
                highscore.High2 = highscore.High1; 
                highscore.High1 = playerscore;  
            }
            else if (high2 > 0 && playerscore < high2 || high2 == 0 && playerscore > high2) 
            {
                highscore.High3 = highscore.High2;
                highscore.High2 = playerscore; 
            }
            else if (high3 > 0 && playerscore < high3 || high3 == 0 && playerscore > high3) 
            { 
                highscore.High3 = playerscore;  
            }

            return highscore;
        }
    }
}
