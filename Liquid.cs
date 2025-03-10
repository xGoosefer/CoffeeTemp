using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTemp
{
    enum LiquidTempType
    {
        Hot,
        Iced
    }
    internal class Liquid
    {
        public string Name = "Coffee";
        public double Temperature = 172;

        public LiquidTempType Type = LiquidTempType.Hot;

    }
}
