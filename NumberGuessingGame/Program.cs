using System;

Random random = new Random();
bool play = true;
int min = 1;
int max = 100;

int guess = 0;
int guessCount = 0;
int numberToGuess = random.Next(min, max + 1);

while(play)
{
    Console.Write("Enter your guess: ");
    guess = int.Parse(Console.ReadLine());

    if(guess < numberToGuess)
    {
        Console.WriteLine("Too low! Try again.");
    }
    else if (guess > numberToGuess)
    {
        Console.WriteLine("Too high! Try again.");
    } else {  
        Console.WriteLine("Congratulations! You guessed the number.");
        Console.WriteLine($"It took you {guessCount} guesses.");
        Console.Write("Do you want to play again? (y/n): ");
        string playAgain = Console.ReadLine();
        if (playAgain.ToLower() == "y" || playAgain.ToLower() == "yes")
        {
            numberToGuess = random.Next(min, max + 1);
            guessCount = 0;
            guess = 0;
            play = true;
        }
        else
        {
            play = false;
        }
    }
    guessCount++;
}

