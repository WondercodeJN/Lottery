using System;


namespace Lottobollar
{
    class Program
    {
        static void Main(string[] args)
        {
            //SETTINGS
            int amountOfRandomNumbers = 10;             //sets the amount of random numbers to put in the array.
            int lowestRandomNumberToGenerate = 1;       //sets the lowest number to generate.
            int highestRandomNumberToGenerate = 25;     //sets the highest number to generate.
            int amountOfUserGuesses = 10;                //sets the amount of user guesses.

            Console.WriteLine("********************************");
            Console.WriteLine("Welcome to the lottery!");
            Console.WriteLine("********************************");
            Console.WriteLine("Please pick {0} numbers", amountOfUserGuesses);
            Console.WriteLine("Write a number and press enter");
            Console.WriteLine("********************************");
            Console.WriteLine("");




            int[] randomNumbersArray; //Creates the array for randomized numbers.
            randomNumbersArray = new int[amountOfRandomNumbers];

           
            for (int i = 0; i < randomNumbersArray.Length; i++) //Fills array with random numbers.
            {
                Random random = new Random();
                int number = random.Next(lowestRandomNumberToGenerate, highestRandomNumberToGenerate);
                randomNumbersArray[i] = number;
            }

            
           
            int[] userGuessesArray; //Creates the array for user input.
            userGuessesArray = new int[amountOfUserGuesses];

            for (int i = 0; i < userGuessesArray.Length; i++)
            {
                try //Safety
                {
                    Console.WriteLine("Please enter a number: ");
                    int userGuess = int.Parse(Console.ReadLine());



                    if (userGuess < lowestRandomNumberToGenerate) //If guessed number is too low.
                    {
                        Console.WriteLine("Your number is too low. ");
                        //userGuess = int.Parse(Console.ReadLine());
                        i = i - 1; //Moves back 1 step in the array - if the user input is higher than allowed value
                    }

                    else if (userGuess > highestRandomNumberToGenerate) //If guess number is too high.
                    {
                        Console.WriteLine("Your number is too high.");
                        // userGuess = int.Parse(Console.ReadLine());
                        i = i - 1; //Moves back 1 step in the array - if the user input is lower than allowed value

                    }

                    else if (userGuess <= 25 && userGuess >= 1)
                    {

                        userGuessesArray[i] = userGuess; //Puts validated user input into userGuessArray.
                        Console.WriteLine("Guess saved!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input - please enter an integrer, ie. a number without decimals.");
                    i = i - 1; //Moves back 1 step in the array - if the user inputs wrong format.
                }
            }


            int[] winningNumbersArray; //Creates the array for winning numbers.
            winningNumbersArray = new int[amountOfRandomNumbers];

            for (int i = 0; i < userGuessesArray.Length; i++) //Compares user input array to randomized numbers array.
            {
                int match = userGuessesArray[i];
                for (int u = 0; u < randomNumbersArray.Length; u++)
                {
                    if (match == randomNumbersArray[u])
                    {
                        winningNumbersArray[i] = match;
                        break;
                    }
                }
            }

            bool youWon = false;
            int winningPoints = 0; //Contains the amount of matches

            for (int i = 0; i < winningNumbersArray.Length; i++)
            {
                if (winningNumbersArray[i] > 0) //Checks if array contains data and also counts how many points the user scored.
                {
                    youWon = true;
                    winningPoints = winningPoints +1;
                }

            }


            Console.Clear();

            if (youWon == true) //Runs if any guess turned out correct, if so - prints to screen.

            {
                Console.WriteLine("You won! You had {0} correct guesses!", winningPoints);
                Console.WriteLine("Your winning numbers were:");
                for (int i = 0; i <winningNumbersArray.Length; i++)
                {
                    if (winningNumbersArray[i] > 0)
                    {
                        Console.Write("*{0}*",winningNumbersArray[i]); //Displays the winning numbers to the user.
                    }
                    }

            }

            else
            {
                Console.WriteLine("sorry you didnt win");
            }

            Console.WriteLine("\n");
            Console.WriteLine("\nThanks for playing!");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to exit the lottery...");
            Console.Read();

            

        }
    }
}
