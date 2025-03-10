/*
 * Coffee Event Handler Demo
 * Roberto A Ramirez, 3/10/2025
 * credits: 
 * Modified and extended from example code at http://www.albahari.com/nutshell/E9-CH04.aspx
 */

using System;

namespace CoffeeTemp
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Coffee Simulation (Event Handlers) by Roberto A. Ramirez";
            Simulation sim = new Simulation();
            sim.SetUp();

        }
    }
}
