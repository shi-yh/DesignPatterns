using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Lobby
    {
        private string sceneName;

        public void CreateRoom(string sceneName)
        {
            this.sceneName = sceneName;
        }

        public void StartGame()
        {
            IGame game = new GameAdapter();


            game.StartScene(sceneName);

            game.EnterPlayer("syh");

        }

    }


    interface IGame
    {
        void StartScene(string sceneName);

        void EnterPlayer(string playerName);

    }


    class GameAdapter : IGame
    {
        private Game game = new Game();

        public void EnterPlayer(string playerName)
        {
            game.EnterPlayer(GetPlayerIDByPlayerName(playerName));
        }

        private int GetPlayerIDByPlayerName(string playerName)
        {
            return 12345;
        }

        public void StartScene(string sceneName)
        {
            game.LoadScene(sceneName, "Abcd1234");
        }




    }


    class Game
    {
        public void LoadScene(string sceneName, string token)
        {
            if (token == "Abcd1234")
            {
                Console.WriteLine("Loading" + sceneName + "...");
            }
            else
            {
                Console.WriteLine("Invalid Token");
            }
        }

        public void EnterPlayer(int playerId)
        {
            Console.WriteLine($"player:{playerId} entered");
        }


    }

}
