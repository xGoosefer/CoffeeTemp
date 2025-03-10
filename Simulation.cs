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
        double envTemp = 75;
        double coolingRate = 0.1;
        double time = 0;
        string timeTYpe = "second";
        string measurementUnit = "degrees";

        public void SetUp()
        {
            if (time > 1) { timeTYpe = timeTYpe + "s"; }
            initialTemp = liquid.Temperature; //get Liquid Temperature
            
            Run();
        }

        private void Run()
        {
            //sim loop
            Console.WriteLine($"Hot Coffee has arrived \n Room: {envTemp}, Hot Coffee: {liquid.Temperature}");
            time++;
            if (timeTYpe == "second")
            {
                if (time > 1) { timeTYpe = timeTYpe + "s"; }
            }
            if (time > 200)
            {
                Console.WriteLine("over 200");
            }
            else
            {
                liquid.Temperature = Math.Floor(NewtonsLawCooling(liquid.Temperature, envTemp, coolingRate, time));

                if (liquid.Temperature > envTemp)
                {
                    Console.WriteLine($"The Temperature of Hot {liquid.Name} is now {liquid.Temperature} {measurementUnit} after {time} {timeTYpe}.");
                    Run();
                }
                else
                {
                    Console.WriteLine($"{liquid.Name} is the same tempurature as {envTemp}.");
                }

            }
            

        }
        //calculates temperature at time t 
        //initial temperature (initialTemperature)
        //environment temperature (envTemperature)
        //cooling constant (coolingConstant)
        //time (time)

        public double NewtonsLawCooling(double initialTemperature, double envTemperature, double coolingConstant, double time)
        {
            // adjust the speed of the temp change depending on how close the Hot Coffee is to the environment 
            if (liquid.Temperature > envTemp + 6)
            {
                return envTemperature + (initialTemperature - envTemperature) * Math.Exp(-coolingConstant * time);
            }
            else
            {
                coolingConstant = coolingRate / 10;
                return envTemperature + (initialTemperature - envTemperature) * Math.Exp(-coolingConstant * time);
            }

        }
    }
}
