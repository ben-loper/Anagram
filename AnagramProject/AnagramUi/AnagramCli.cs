using AnagramProject.AnagramGame;
using AnagramProject.AnagramGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramProject.AnagramUi
{
    public class AnagramCli : IAnagramUi
    {
        private IAnagramGame game;

        public AnagramCli(IAnagramGame _game)
        {
            game = _game;
        }

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the game!");
                Console.WriteLine("Choose your difficulty!");
                Console.WriteLine($"1: {DifficultyLevel.Easy}");
                Console.WriteLine($"2: {DifficultyLevel.Medium}");
                Console.WriteLine($"3: {DifficultyLevel.Hard}");
                Console.WriteLine("Q: Quit");

                String choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "1":
                        EasyMode();
                        break;
                    case "2":
                        MediumMode();
                        break;
                    case "3":
                        HardMode();
                        break;
                    case "q":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Come on... really?");
                        Console.WriteLine("Press any key to try again");
                        Console.ReadKey();
                        break;
                }
            }
            
        }

        private void EasyMode()
        {
            bool playAgain = true;
            
            while (playAgain)
            {
                AnagramWord easyWord = game.LoadEasyWord();
                playAgain = GameScreen(easyWord, DifficultyLevel.Easy);
            }
        }

        private void MediumMode()
        {
            bool playAgain = true;

            while (playAgain)
            {
                AnagramWord mediumWord = game.LoadMediumWord();
                playAgain = GameScreen(mediumWord, DifficultyLevel.Medium);
            }
        }

        private void HardMode()
        {
            bool playAgain = true;

            while (playAgain)
            {
                AnagramWord hardWord = game.LoadHardWord();
                playAgain = GameScreen(hardWord, DifficultyLevel.Hard);
            }
        }

        private bool GameScreen(AnagramWord word, Enum difficulty)
        {
            bool gameOver = false;
            bool playAgain = false;

            int numOfAttempts = 0;
            int numOfCorrectCharacters = 0;
            List<string> previousGuesses = new List<string>();

            while (!gameOver)
            {
                Console.Clear();
                Console.WriteLine($"{difficulty} Mode!");
                Console.WriteLine("\n******************************************************\n");
                Console.WriteLine($"Word to guess: {word.JumbledWord}\n\n******************************************************\n");
                Console.WriteLine($"Number of Attempts: {numOfAttempts}");
                Console.WriteLine($"Number of Correct characters from previous try: {numOfCorrectCharacters}\n\n******************************************************\n");

                string previousGuessesCommaSeperated = "";

                for (int i = 0; i < previousGuesses.Count; i++)
                {
                    if (i + 1 == previousGuesses.Count)
                    {
                        previousGuessesCommaSeperated += previousGuesses[i];
                    }
                    else
                    {
                        previousGuessesCommaSeperated += $"{previousGuesses[i]}, ";
                    }
                }

                Console.WriteLine($"Previous guesses: {previousGuessesCommaSeperated}\n\n******************************************************\n");
                Console.Write("Enter your guess (q to go back to main menu): ");

                string userGuess = Console.ReadLine().ToLower();
                numOfAttempts++;

                if (userGuess == "q")
                {
                    gameOver = true;                    
                }
                else if (game.DoWordsMatch(userGuess, word.Word))
                {

                    bool validChoice = false;

                    while (!validChoice)
                    {
                        WinScreen(numOfAttempts, word);
                        string retryChoice = Console.ReadLine().ToLower();

                        if (retryChoice == "y")
                        {
                            playAgain = true;
                            validChoice = true;
                            gameOver = true;                            
                        }
                        else if (retryChoice == "n")
                        {
                            gameOver = true;
                            validChoice = true;
                            playAgain = false;
                        }
                    }
                }
                else
                {
                    previousGuesses.Add(userGuess);
                    numOfCorrectCharacters = game.NumberOfMatchingCharacters(userGuess, word.Word);
                }
            }

            return playAgain;
        }

        private void WinScreen(int numOfTries, AnagramWord word)
        {
            Console.Clear();
            if(word.Difficulty == DifficultyLevel.Easy)
            {
                Console.WriteLine($"Congrats! You just unscrambled an {word.Difficulty} level word!");
            }
            else
            {
                Console.WriteLine($"Congrats! You just unscrambled a {word.Difficulty} level word!");
            }
            
            Console.WriteLine("\n******************************************************\n");
            Console.WriteLine($"You guessed the word {word.Word} jumbled as {word.JumbledWord} in {numOfTries} attempts!\n\n******************************************************\n");
            Console.Write($"Try again? (y/n): ");

        }
    }
}
