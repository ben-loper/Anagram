using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnagramProject.AnagramGame.DAO
{
    public class FileSystemWordDao : IWordDao
    {
        public List<string> GetEasyWords()
        {
            string[] words;          

            String fileContent = File.ReadAllText(Directory.GetCurrentDirectory() + "../../../../WordBank/EasyWords.txt");       

            words = fileContent.Split(",");

            List<string> copiedWords = new List<string>(words);

            return copiedWords;
        }

        public List<string> GetMediumWords()
        {
            string[] words;

            String fileContent = File.ReadAllText(Directory.GetCurrentDirectory() + "../../../../WordBank/MediumWords.txt");

            words = fileContent.Split(",");

            List<string> copiedWords = new List<string>(words);

            return copiedWords;
        }

        public List<string> GetHardWords()
        {
            string[] words;

            String fileContent = File.ReadAllText(Directory.GetCurrentDirectory() + "../../../../WordBank/HardWords.txt");

            words = fileContent.Split(",");

            List<string> copiedWords = new List<string>(words);

            return copiedWords;
        }
    }
}
