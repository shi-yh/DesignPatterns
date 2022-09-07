using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IFactory
    {
        IProduct CreateProduct();
    }

    public class FactoryComputer : IFactory
    {
        public virtual IProduct CreateProduct()
        {
            return default(Computer);
        }
    }

    public class FactoryIPhone : IFactory
    {
        public virtual IProduct CreateProduct()
        {
            return default(IPhone);
        }
    }

    public class FactoryMac : IFactory
    {
        public virtual IProduct CreateProduct()
        {
            return default(Mac);
        }
    }

    public class FactoryIPad : IFactory
    {
        public virtual IProduct CreateProduct()
        {
            return default(IPad);
        }
    }






    class FactoryMethod
    {

    }
}
