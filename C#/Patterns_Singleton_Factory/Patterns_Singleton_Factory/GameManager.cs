using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Singleton_Factory
{
    class GameManager
    {
        private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>( () => new GameManager());
        public static GameManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public int Score { get; set; }
        public int NumberOfEnemies { get; set; }

        private GameManager() { }

        public void LoadLevel(int level)
        {
            Console.WriteLine("Loading level {0}", level);
            Console.WriteLine("Level Loaded!");
        }

        public void GameWin()
        {
            Console.WriteLine("GAME WIN!");
        }
    }
}
