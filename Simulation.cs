using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoffeeTemp
{
    internal class Simulation
    {
        Liquid liquid = new Liquid();
        decimal temperature = Utility.RandomNumber.Next(65, 75);
        double initialTemp = 0;
        double envTemp = 0.1;
        double coolingRate = 0.1;
        double time = 0;
        string timeTYpe = "second";
        string measurementUnit = "degrees";

        public void SetUp()
        {
            if (time > 1) { timeTYpe = timeTYpe + "s"; }
            initialTemp = liquid.Temperature; //get Liquid Temperature
        }
    }
}
