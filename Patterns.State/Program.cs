using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.State
{
    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(WaterState.LIQUID);
            water.Heat();
            water.Frost();
            water.Frost();

            Console.Read();
        }
    }
    enum WaterState
    {
        SOLID,
        LIQUID,
        GAS
    }
    class Water
    {
        public WaterState State { get; set; }

        public Water(WaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            if (State == WaterState.SOLID)
            {
                Console.WriteLine("Transforming ice into liquid");
                State = WaterState.LIQUID;
            }
            else if (State == WaterState.LIQUID)
            {
                Console.WriteLine("Transforming liquid into vapor");
                State = WaterState.GAS;
            }
            else if (State == WaterState.GAS)
            {
                Console.WriteLine("Increase the temperature of water vapor");
            }
        }
        public void Frost()
        {
            if (State == WaterState.LIQUID)
            {
                Console.WriteLine("Transforming the liquid into ice");
                State = WaterState.SOLID;
            }
            else if (State == WaterState.GAS)
            {
                Console.WriteLine("We convert steam to liquid");
                State = WaterState.LIQUID;
            }
        }
    }
}
