using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    abstract class Element
    {
        protected string name;

        public Element(string name)
        {
            this.name = name;
        }

        public abstract void Add(Element element);

        public abstract void Remove(Element element);

        public abstract void Display();

        public abstract void Start();


        public abstract void Stop();

    }


    class GameArea : Element
    {
        private List<GameServer> serverList = new List<GameServer>();

        public GameArea(string name) : base(name)
        {
        }

        public override void Add(Element element)
        {
            serverList.Add((GameServer)element);
        }

        public override void Display()
        {
            Console.WriteLine(new string('=', 20));
            Console.WriteLine(" " + name);
            Console.WriteLine(new string('=', 20));
            foreach (Element element in serverList)
            {
                element.Display();
            }
        }

        public override void Remove(Element element)
        {
            serverList.Remove((GameServer)element);
        }

        public override void Start()
        {
            Console.WriteLine("=============Starting the whole " + name + "=============");
            foreach (Element element in serverList)
            {
                element.Start();
            }
            Console.WriteLine("=============The whole " + name + "started ============= ");
        }

        public override void Stop()
        {
            Console.WriteLine("=============Stopping the whole " + name + "=============");
            foreach (Element element in serverList)
            {
                element.Stop();
            }
            Console.WriteLine("=============The whole " + name + " stopped ============= ");
        }
    }

    class GameServer : Element
    {
        private string serverIp;
        private List<GameService> serviceList = new List<GameService>();


        public GameServer(string name, string serverIp) : base(name)
        {
            this.serverIp = serverIp;
        }

        public override void Add(Element element)
        {
            serviceList.Add((GameService)element);
        }

        public override void Display()
        {
            Console.WriteLine(string.Format("{0}{1}{2}{3}", new string('+', 10),
                name,
                serverIp,
                new string('+', 10)));
        }

        public override void Remove(Element element)
        {
            serviceList.Remove((GameService)element);
        }

        public override void Start()
        {
            serviceList.Sort();
            Console.WriteLine("================Strating the whole " + name + "================");

            for (int i = 0; i < serviceList.Count; i++)
            {
                serviceList[i].Start();
            }

            Console.WriteLine("================The whole " + name + "started================");


        }

        public override void Stop()
        {
            Console.WriteLine("=============Stopping the whole " + name + "=============");
            for (int i = serviceList.Count - 1; i >= 0; i--)
            {
                serviceList[i].Stop();
            }
            Console.WriteLine("=============The whole " + name + "stopped ============= ");
        }
    }


    class GameService : Element, IComparable<GameService>
    {
        private int serviceType;

        private string serviceName;


        public GameService(string name, int serviceType, string serviceName) : base(name)
        {
            this.serviceType = serviceType;
            this.serviceName = serviceName;
        }

        public override void Add(Element element)
        {
            throw new ApplicationException("xxx");
        }

        public int CompareTo(GameService other)
        {
            return other.serviceType.CompareTo(serviceType);
        }

        public override void Display()
        {
            Console.WriteLine(string.Format("name:{0},serviceType:{1},serviceName:{2}",
      name,
      serviceType,
      serviceName));
        }

        public override void Remove(Element element)
        {
            throw new ApplicationException("xxx");
        }

        public override void Start()
        {
            Console.WriteLine(string.Format("{0} started", name));
        }

        public override void Stop()
        {
            Console.WriteLine(string.Format("{0} stopped", name));
        }
    }

}
