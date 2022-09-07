using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class ModelFactory
    {
        private Hashtable modelList = new Hashtable();

        private static ModelFactory instance;

        public static ModelFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ModelFactory();
            }

            return instance;
        }

        public Model2 GetModel(string ModelName)
        {
            Model2 model = modelList[ModelName] as Model2;

            if (model == null)
            {
                model = new Model2(ModelName);
                modelList.Add(ModelName, model);
            }

            return model;

        }

    }

    class Model2
    {
        private byte[] data;

        public Model2(string modelName)
        {

            data = File.ReadAllBytes("G:\\CSharpProject\\DesignPatterns\\DesignPatterns\\Resource\\" + modelName + ".txt");
        }

    }
}
