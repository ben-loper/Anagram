using AnagramProject.AnagramGame.DAO;
using AnagramProject.AnagramGame.Models;
using System;
using System.Collections.Generic;

namespace AnagramProject.AnagramGame
{
    public class Anagram : IAnagramGame
    {
        private IWordDao _wordDao;

        public Anagram(IWordDao wordDao)
        {
            _wordDao = wordDao;
        }

        public AnagramWord LoadEasyWord()
        {
            List<string> words = _wordDao.GetEasyWords();

            Random rnd = new Random();

            int randomIndex = rnd.Next(words.Count);
            string selectedWord = words[randomIndex];

            AnagramWord word = new AnagramWord();

            word.Word = selectedWord;
            word.JumbledWord = ScrambleWord(selectedWord);
            word.Difficulty = DifficultyLevel.Easy;

            while(word.Word == word.JumbledWord)
            {
                word.JumbledWord = ScrambleWord(selectedWord);
            }

            return word;
        }

        public AnagramWord LoadMediumWord()
        {
            List<string> words = _wordDao.GetMediumWords();

            Random rnd = new Random();

            int randomIndex = rnd.Next(words.Count);
            string selectedWord = words[randomIndex];

            AnagramWord word = new AnagramWord();

            word.Word = selectedWord;
            word.JumbledWord = ScrambleWord(selectedWord);
            word.Difficulty = DifficultyLevel.Medium;

            while (word.Word == word.JumbledWord)
            {
                word.JumbledWord = ScrambleWord(selectedWord);
            }

            return word;
        }

        public AnagramWord LoadHardWord()
        {
            List<string> words = _wordDao.GetHardWords();

            Random rnd = new Random();

            int randomIndex = rnd.Next(words.Count);
            string selectedWord = words[randomIndex];

            AnagramWord word = new AnagramWord();

            word.Word = selectedWord;
            word.JumbledWord = ScrambleWord(selectedWord);
            word.Difficulty = DifficultyLevel.Hard;

            while (word.Word == word.JumbledWord)
            {
                word.JumbledWord = ScrambleWord(selectedWord);
            }

            return word;
        }

        public bool DoWordsMatch(string guessWord, string actualWord) {            
            return guessWord == actualWord;
        }

        public int NumberOfMatchingCharacters(string guessWord, string actualWord)
        {
            int result = 0;

            for(int i = 0; i < actualWord.Length; i++)
            {
                if(guessWord.Length > i && actualWord[i] == guessWord[i])
                {
                    result++;
                }
            }

            return result;
        }

        private string ScrambleWord(string word)
        {            
            Random rnd = new Random();

            char[] unusedLetters = word.ToCharArray();
            List<char> unusedCharacters = new List<char>(unusedLetters);
            List<char> jumbledCharacters = new List<char>();

            while(unusedCharacters.Count > 0)
            {
                int randomIndex = rnd.Next(unusedCharacters.Count);
                jumbledCharacters.Add(unusedCharacters[randomIndex]);
                unusedCharacters.RemoveAt(randomIndex);
            }

            return new string(jumbledCharacters.ToArray());
        }
    }
}
