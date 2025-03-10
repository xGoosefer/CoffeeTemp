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
            initialTemp = liquid.Temperature; //get Liquid 
            Run();
            liquid.Type = LiquidTempType.Iced;
            liquid.Temperature = 50;
            time = 0;
            Run();
           
        }

        private void Run()
        {
            //sim loop
            Console.WriteLine($"{liquid.Type} Coffee has arrived \n Room: {envTemp}, {liquid.Type} Coffee: {liquid.Temperature}");
            time++;
            if (timeTYpe == "second")
            {
                if (time > 1) { timeTYpe = timeTYpe + "s"; }
            }
            if (time > 200)
            {
                Console.WriteLine($"Over 200 {timeTYpe} have passed and {liquid.Type} {liquid.Name} is still {liquid.Temperature} {measurementUnit}!");
            }
            else
            {
                liquid.Temperature = Math.Floor(NewtonsLawCooling(liquid.Temperature, envTemp, coolingRate, time));

                if (liquid.Temperature != envTemp)
                {
                    Console.WriteLine($"The Temperature of {liquid.Type}" +
                        $" {liquid.Name} is now {liquid.Temperature} {measurementUnit} after {time} {timeTYpe}.");
                    Run();
                }
                else
                {
                    Console.WriteLine($"{liquid.Name} is the same tempurature as the Room ({envTemp} {measurementUnit}). \n");
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
            double tempDiff = Math.Abs( liquid.Temperature - envTemp);
            if (tempDiff > 6)
            {
                return envTemperature + (initialTemperature - envTemperature) * Math.Exp(-coolingConstant * time);
            }
            else 
            {
                coolingConstant = coolingRate / 5;
                return envTemperature + (initialTemperature - envTemperature) * Math.Exp(-coolingConstant * time);
            }
            

        }
    }
}
