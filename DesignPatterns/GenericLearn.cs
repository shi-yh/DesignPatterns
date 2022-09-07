using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class GenericLearn
    {
    }

    public class Shape
    {
        public string shapeName;

        public int shapeId;
    }

    public class Triangle : Shape
    {

    }

    public class Square : Shape
    {

    }


    public class GenericCachePool
    {
        static Dictionary<string, Shape> cacheDic;

        static GenericCachePool()
        {
            cacheDic = new Dictionary<string, Shape>();
        }

        /// <summary>
        /// 泛型缓存
        /// </summary>
        /// <typeparam name="CacheType"></typeparam>
        /// <returns></returns>
        public static CacheType GetCache<CacheType>() where CacheType:Shape,new()
        {
            string cacheName = typeof(CacheType).ToString();

            CacheType finalResult = null;

            if (cacheDic.ContainsKey(cacheName))
            {
                finalResult = cacheDic[cacheName] as CacheType;
            }
            else
            {
                finalResult = new CacheType();
                cacheDic.Add(cacheName, finalResult);
            }

            return finalResult;

        }


    }

}
