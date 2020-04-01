using AnagramProject.AnagramGame;
using AnagramProject.AnagramGame.DAO;
using AnagramProject.AnagramUi;

namespace AnagramProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IWordDao wordDao = new FileSystemWordDao();
            IAnagramGame gameObj = new Anagram(wordDao);

            IAnagramUi game = new AnagramCli(gameObj);

            game.Start();
        }
    }
}
