/*
FINAL PROJECT -
Ryla Stark - May 3rd 2026
    Number Guessing Game
        - allows the user up to 5 tries to guess a number between 1 and 100
        - prompts the user for if they want to try again or not
        - keeps track of hint amount
        - allows hints on too high or too low
        - uses abstract classes, inheritance, and interfaces
*/
using System;

// use of interface
interface IGuess
{
    void PlayGame();
}
// use of abstract class
abstract class GuessingGame
{
    // keep track of number of hints
    protected int hintNum;
    // use of abstract method
    public abstract void print();
    // show how many hints were given before game ended at 5 tries
    public void ShowHintsGiven()
    {
        Console.WriteLine("Total tries/hints given: " + hintNum);
    }
}
// GUESSING CLASS
// use of inheritance
class NumberGuessingGame : GuessingGame, IGuess
{
    //keep track of the number, the guess that the user gives, then the secret number the program generated
    private int number;
    private int guess;
    private Random random = new Random();
    // abstract method override to print rules of game
    public override void print()
    {
        Console.WriteLine("----- Number Guessing Game -----");
        Console.WriteLine("Guess any number between 1 and 100.");
        Console.WriteLine("** Hints will be given if your guess was too high or too low. You get 5 chances. **");
    }
    // this is called to run the actual game
    public void PlayGame()
    {
        string replayYes = "REPLAY";
        // runs game if prompted
        while (replayYes == "REPLAY")
        {
            // starts game with 0 hints, allows user to guess & generates number between 1 and 100
            hintNum = 0;
            int guessCount = 0;
            number = random.Next(1, 101);
            
            //print instructions
            print();

            // while we are within 5 guesses, run
            while (guessCount < 5)
            {   
                // prompts user for guess & takes guess into guess variable
                Console.Write("Enter number guess: ");
                guess = int.Parse(Console.ReadLine());

                // increase guess count
                guessCount++;
                
                //PRINT TOO HIGH OR TOO LOW
                //too low
                if (guess < number)
                {
                    Console.WriteLine("Hint: Too low!");
                    hintNum++;
                }
                //too high
                else if (guess > number)
                {
                    Console.WriteLine("Hint: Too high!");
                    hintNum++;
                }
                //ends game
                else
                {
                    Console.WriteLine("CONGRATS! YOU GUESSED THE NUMBER!");
                    break;
                }
            }
            // if game maxes out tell user game is over and print answer
            if (guess != number)
            {
                Console.WriteLine("You ran out of hints!");
                Console.WriteLine("The number was: " + number);
            }
            
            //show the amount of hints the user had used
            ShowHintsGiven();

            // prompt for replayYes variable to see if method needs to be called again
            Console.Write("Do you want to play again? Answer with REPLAY/END: ");
            replayYes = Console.ReadLine();
            
            // if user doesn't want to play again, thank the user for playing
            if (replayYes != "REPLAY")
            {
                Console.WriteLine("Thank you for playing the number guessing game!");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        //create game
        NumberGuessingGame game = new NumberGuessingGame();
        //start game
        game.PlayGame();
    }
}