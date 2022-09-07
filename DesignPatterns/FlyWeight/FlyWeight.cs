using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class ModelFactory
    {

    }

    class Model2
    {
        private byte[] data;

        public Model2(string modelName)
        {
            data = File.ReadAllBytes("c:\\" + modelName + ".txt");
        }

    }
}
