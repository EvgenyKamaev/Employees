using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employes.Web.Tools
{
    public class Singleton
    {
        private static readonly IDictionary<Type, Object> allSigletons;

        static Singleton()
        {
            allSigletons = new Dictionary<Type, Object>();
        }

        public static IDictionary<Type, Object> AllSigletons
        {
            get { return allSigletons; }
        }
    }

    public class Sigleton<T> : Singleton
    {
        private static T _instance;

        public static T Instance
        {
            get { return _instance; }
            set
            {
                _instance = value;
                AllSigletons[typeof(T)] = value;
            }
        }
    }
}