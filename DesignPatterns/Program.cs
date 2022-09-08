using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns
{

    class Program
    {

        static void Main(string[] args)
        {
            Program program = new Program();

            program.TestBridge();

        }

        private void TestBridge()
        {
            PatrixScene halfPaper = new HalfPaperScene();

            halfPaper.Mode = new GoldMode();

            halfPaper.LoadScene();

            PatrixScene matrix = new MatrixScene();

            matrix.Mode = new PropertyMode();

            matrix.LoadScene();


        }


        private void TestComposite()
        {
            Element server1 = new GameServer("GS1", "192.168.0.1");

            server1.Add(new GameService("Lobby1", 1, "SSLobby"));
            server1.Add(new GameService("Gate1", 2, "SSGate1"));
            server1.Add(new GameService("DataExchange1", 1, "SSDataExchange1"));
            server1.Add(new GameService("Rank1", 1, "SSRank1"));
            server1.Add(new GameService("Log1", 1, "SSLog1"));


            Element server2 = new GameServer("GS2", "192.168.0.2");
            server2.Add(new GameService("Lobby2", 1, "S5Lobby2"));
            server2.Add(new GameService("Gate2", 2, "S5Gate2"));
            server2.Add(new GameService("DataExchange2", 3, "S5DataExchange1"));
            server2.Add(new GameService("Rank2", 4, "S5Rank2"));
            server2.Add(new GameService("Log2", 5, "S5Log2"));

            Element area = new GameArea("电信区");
            area.Add(server1);
            area.Add(server2);
            area.Display();
            area.Start();
            area.Stop();


        }


        private void TestSingleton()
        {
            ParameterizedThreadStart ts = new ParameterizedThreadStart(EnterPlayer);

            for (int i = 0; i < 20; i++)
            {
                Thread t = new Thread(ts);

                t.Start("player" + i);

            }

            Singleton.GetSingletonServer().ShowServerInfo();
        }

        static void EnterPlayer(object playerName)
        {
            Singleton.GetSingletonServer().GetLobbyServer().EnterPlayer(playerName.ToString());
        }


        private void TestResponsibility()
        {
            ResponsibilityContext context = new ResponsibilityContext();

            FoodHandler fh1 = new DrinkHandler();
            FoodHandler fh2 = new VegetableHandler();
            FoodHandler fh3 = new MeatHandler();

            fh1.SetSuccessor(fh2);
            fh2.SetSuccessor(fh3);

            fh1.HandleRequest(context);

            Console.WriteLine($"是否处理成功{context.AuditResult}");
            Console.WriteLine($"Remark{context.AuditRemark}");

        }


        private void TestBuild()
        {
            AbsrtactBuilder absrtactBuilder = new HouseBuilder();

            Director director = new Director(absrtactBuilder);

            House house = director.GetResult();
        }


        private void TestPrototype()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            Enemy enemy = new FootMan(5, 4, new Location(100, 200));

            GameScene gameScene = new GameScene();

            List<Enemy> enemyGroup = gameScene.CreateEnemyGroup(enemy);

            foreach (FootMan item in enemyGroup)
            {
                item.ShowInfo();
                item.FootManAttack();
            }

            Console.WriteLine(sw.ElapsedMilliseconds);

        }


        /// <summary>
        /// 测试简单工厂
        /// </summary>
        private void TestSimpleFactory()
        {
            Computer cp = SimpleFactory.CreateProduct(ProductType.Computer) as Computer;

            //cp dosomething

            IProduct ip = SimpleFactory.CreateProduct(ProductType.Computer);

            //ip doCommonFunc

        }

        private void TestFactoryMethod()
        {
            //感觉写成 computer cp=Factory.


            IFactory factory = new FactoryComputer();
            IProduct computer = factory.CreateProduct();

            factory = new FactoryIPhone();
            IProduct iPhone = factory.CreateProduct();

            factory = new FactoryMac();
            IProduct mac = factory.CreateProduct();

            factory = new FactoryIPad();
            IProduct iPad = factory.CreateProduct();
        }


        private void TestAbstractFactory()
        {
            Patrix patrix = new Patrix();

            patrix.LoadScene("HalfPaper");

            patrix.LoadScene("Matrix");

        }

        private void TestAdapter()
        {
            Lobby lobby = new Lobby();

            lobby.CreateRoom("HalfPaper");

            lobby.StartGame();

        }

        private void TestPayFacade()
        {
            PayFacade pf = new PayFacade();

            Console.WriteLine("order:" + pf.CreateOrder("syh", 0, 1, 12) + "created");

        }


        private void TestFlyWeight()
        {
            Console.WriteLine(GC.GetTotalMemory(false));

            Random rnd = new Random();

            ArrayList al = new ArrayList();

            for (int i = 0; i < 10000; i++)
            {
                string modelName = rnd.Next(2).ToString();

                Model2 model = ModelFactory.GetInstance().GetModel(modelName);

                al.Add(model);
            }


            Console.WriteLine(GC.GetTotalMemory(false));
        }

        private void TestProxy()
        {
            AccountProxy ap = new AccountProxy();

            ap.Register();


        }

    }
}
