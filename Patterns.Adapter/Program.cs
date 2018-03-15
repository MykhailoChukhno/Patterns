using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            Auto auto = new Auto();
            driver.Travel(auto);
            Camel camel = new Camel();
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);

            Console.Read();
        }
    }
    interface ITransport
    {
        void Drive();
    }
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("The car is on the road");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    interface IAnimal
    {
        void Move();
    }
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("A camel walks through the desert sand");
        }
    }
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}
