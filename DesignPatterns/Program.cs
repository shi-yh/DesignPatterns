using System;
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

            program.TestPayFacade();

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

    }
}
