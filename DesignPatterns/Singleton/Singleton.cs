using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Singleton
    {
        private List<LobbyServer> servers = new List<LobbyServer>();

        private static volatile Singleton _instance;

        private static object syncLock = new object();

        private Singleton()
        {
            for (int i = 0; i < 3; i++)
            {
                servers.Add(new LobbyServer("LobbyServer" + i));
            }
        }

        public static Singleton GetSingletonServer()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        ///模拟高并发，然后才创建
                        Thread.Sleep(100);
                        _instance = new Singleton();
                    }
                }
            }

            return _instance;
        }


        public LobbyServer GetLobbyServer()
        {
            LobbyServer ls = servers[0];

            for (int i = 0; i < servers.Count; i++)
            {
                if (servers[i].PlayerList.Count < ls.PlayerList.Count)
                {
                    ls = servers[i];
                }
            }

            return ls;
        }

        public void ShowServerInfo()
        {
            foreach (LobbyServer item in servers)
            {
                Console.WriteLine($"==================={item.ServerName}======================");

                foreach (var player in item.PlayerList)
                {
                    Console.WriteLine(player);
                }

            }
        }
    }


    class LobbyServer
    {
        private List<string> playerList = new List<string>();

        public List<string> PlayerList { get { return playerList; } }

        private string serverName;

        public string ServerName { get { return serverName; } }

        public LobbyServer(string serverName)
        {
            this.serverName = serverName;
        }

        public void EnterPlayer(string playerName)
        {
            playerList.Add(playerName);
        }


    }

}
