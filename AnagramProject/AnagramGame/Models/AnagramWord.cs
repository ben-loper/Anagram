using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramProject.AnagramGame.Models
{
    public class AnagramWord
    {
        public String Word { get; set; }
        public String JumbledWord { get; set; }
        public DifficultyLevel Difficulty { get; set; }
    }
}
