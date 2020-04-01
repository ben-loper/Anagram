using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramProject.AnagramGame.DAO
{
    public interface IWordDao
    {
        public List<string> GetEasyWords();
        public List<string> GetMediumWords();
        public List<string> GetHardWords();
    }
}
