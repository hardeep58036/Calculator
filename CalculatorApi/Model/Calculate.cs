using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApi.Model
{
    public class Calculate
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public char Operator { get; set; }
    }
}
