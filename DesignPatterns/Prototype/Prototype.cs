using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace DesignPatterns
{
    [Serializable]
    class Location
    {
        public int x;

        public int y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    [Serializable]
    abstract class Enemy
    {
        protected Location location;

        public Location Location
        {
            get => location;
            set => location = value;
        }


        protected int power;

        public int Power
        {
            get => power;
            set => power = value;
        }

        protected int speed;

        public int Speed
        {
            get => speed; set => speed = value;
        }

        public abstract Enemy Clone(bool isDeepCopy);

        public abstract void ShowInfo();

        public Enemy(int power, int speed, Location location)
        {
            Thread.Sleep(1000);
            this.power = power;
            this.speed = speed;
            this.location = location;
        }
    }

    [Serializable]
    class FootMan : Enemy
    {
        private string model;

        public FootMan(int power, int speed, Location location) : base(power, speed, location)
        {
            model = "footMan";
        }


        public override void ShowInfo()
        {
            Console.WriteLine($"model:{model} power:{power} speed:{speed} location:({location.x},{location.y})");
        }

        public override Enemy Clone(bool isDeepCopy)
        {
            FootMan footman;

            if (isDeepCopy)
            {
                MemoryStream memoryStream = new MemoryStream();

                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(memoryStream, this);

                memoryStream.Position = 0;

                footman = (FootMan)formatter.Deserialize(memoryStream);
            }
            else
            {
                footman = (FootMan)this.MemberwiseClone();
            }

            return footman;
        }

        public void FootManAttack()
        {
            Console.WriteLine("FootMan Attack");
        }

    }

    class GameScene
    {
        public List<Enemy> CreateEnemyGroup(Enemy enemyPrototype)
        {
            List<Enemy> enemyGroup = new List<Enemy>();

            Enemy e1 = enemyPrototype.Clone(true);

            e1.Location.x = enemyPrototype.Location.x - 20;

            Enemy e2 = enemyPrototype.Clone(true);

            e2.Location.x = enemyPrototype.Location.x + 10;

            Enemy elite = enemyPrototype.Clone(true);

            elite.Power = enemyPrototype.Power * 2;
            elite.Speed = enemyPrototype.Speed * 2;

            elite.Location.x = enemyPrototype.Location.x;
            elite.Location.y = enemyPrototype.Location.y + 10;

            enemyGroup.Add(e1);
            enemyGroup.Add(e2);
            enemyGroup.Add(elite);

            return enemyGroup;
        }



    }



}
