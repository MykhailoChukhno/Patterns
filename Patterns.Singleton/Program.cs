using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }

    class OS
    {
        private static OS instance;

        public string Name { get; private set; }
        private static object syncRoot = new Object();

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
            return instance;
        }
    }
    public class SingletonLazy
    {
        public string Name { get; private set; }

        private SingletonLazy()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static SingletonLazy GetInstance()
        {
            return Nested.instance;
        }

        private class Nested
        {
            internal static readonly SingletonLazy instance = new SingletonLazy();
        }
    }
    public class SingletonLazyT
    {
        private static readonly Lazy<SingletonLazyT> lazy =
            new Lazy<SingletonLazyT>(() => new SingletonLazyT());

        public string Name { get; private set; }

        private SingletonLazyT()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static SingletonLazyT GetInstance()
        {
            return lazy.Value;
        }
    }
}
