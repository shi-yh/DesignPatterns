using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /// <summary>
    /// 水泥
    /// </summary>
    public class Cement { }
    /// <summary>
    /// 砖块
    /// </summary>
    public class Brick { }
    /// <summary>
    /// 钢筋
    /// </summary>
    public class Rebar { }
    /// <summary>
    /// 楼层
    /// </summary>
    public class Floor { }

    /// <summary>
    /// 水
    /// </summary>
    public class Water { }
    /// <summary>
    /// 电
    /// </summary>
    public class Electricity { }
    /// <summary>
    /// 房屋
    /// </summary>
    public class House { }

    public abstract class AbsrtactBuilder
    {
        public abstract void Build_Cement();
        public abstract void Build_Brick();
        public abstract void Build_Rebar();
        public abstract void Build_Floor();
        public abstract void Build_Water();
        public abstract void Build_Electricity();
        public abstract House Build_House();

    }


    public class HouseBuilder : AbsrtactBuilder
    {
        public override void Build_Brick()
        {
            Console.WriteLine("建造砖块");
        }
        public override void Build_Cement()
        {
            Console.WriteLine("建造水泥");
        }
        public override void Build_Electricity()
        {
            Console.WriteLine("建造电力");
        }
        public override void Build_Floor()
        {
            Console.WriteLine("建造楼层");
        }
        public override void Build_Rebar()
        {
            Console.WriteLine("建造钢筋");
        }
        public override void Build_Water()
        {
            Console.WriteLine("建造水");
        }
        public override House Build_House()
        {
            Console.WriteLine("房屋建造完成");
            return new House();
        }
    }

    public class Director
    {
        private AbsrtactBuilder abstractBuilder;

        public Director(AbsrtactBuilder absrtactBuilder)
        {
            this.abstractBuilder = absrtactBuilder;
        }

        public House GetResult()
        {
            abstractBuilder.Build_Brick();//建造砖块
            abstractBuilder.Build_Cement();//建造水泥
            abstractBuilder.Build_Rebar();//建造钢筋
            abstractBuilder.Build_Floor();//建造楼层
            abstractBuilder.Build_Electricity();//电力完成
            abstractBuilder.Build_Water();//水源完成
            House temp = abstractBuilder.Build_House();//成品房屋完成

            return temp;
        }

    }




    class Builder
    {
    }
}
