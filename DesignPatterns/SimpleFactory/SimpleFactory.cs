using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public enum ProductType
    {
        None,

        Computer,

        IPhone,

        Mac,

        IPad
    }


    public interface IProduct { };

    public class Computer : IProduct { }

    public class IPhone : IProduct { }

    public class Mac : IProduct { }

    public class IPad : IProduct { }


    /// <summary>
    /// 简单工厂，不关注实现细节且需创建在概念上相同的元素
    /// </summary>
    class SimpleFactory
    {
        public static IProduct CreateProduct(ProductType productType)
        {
            IProduct tempProduct = null;

            switch (productType)
            {
                case ProductType.Computer:
                    {
                        tempProduct = new Computer();
                    }
                    break;
                case ProductType.IPhone:
                    {
                        tempProduct = new IPhone();
                    }
                    break;
                case ProductType.Mac:
                    {
                        tempProduct = new Mac();
                    }
                    break;
                case ProductType.IPad:
                    {
                        tempProduct = new IPad();
                    }
                    break;
                default:
                    {
                    }
                    break;
            }

            return tempProduct;
        }
     
	}





}

