using AnagramProject.AnagramGame.Models;

namespace AnagramProject.AnagramGame
{
    public interface IAnagramGame
    {
        public AnagramWord LoadEasyWord();
        public AnagramWord LoadMediumWord();
        public AnagramWord LoadHardWord();
        public bool DoWordsMatch(string guessWord, string actualWord);
        public int NumberOfMatchingCharacters(string guessWord, string actualWord);
    }
}
