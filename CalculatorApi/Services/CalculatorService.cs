using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApi.Services
{
    public interface ICalculatorService
    {
        double Add(double firstNumber, double secondNumber);
        double Subtract(double firstNumber, double secondNumber);
        double Multiply(double firstNumber, double secondNumber);
        double Divide(double firstNumber, double secondNumber);
        double Remainder(double firstNumber, double secondNumber);

    }

    public class CalculatorService : ICalculatorService
    {
        public double Add(double firstNumber, double secondNumber)
        {
            //return Math.Round((firstNumber + secondNumber),2);
            var result = Math.Round((firstNumber + secondNumber), 2);
            return result;

        }

        public double Divide(double firstNumber, double secondNumber)
        {
            var result= Math.Round((firstNumber / secondNumber), 2);
            return result;
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            return Math.Round((firstNumber * secondNumber),2);
        }

        public double Remainder(double firstNumber, double secondNumber)
        {
            return Math.Round((firstNumber % secondNumber),2);
        }

        public double Subtract(double firstNumber, double secondNumber)
        {
            return Math.Round((firstNumber - secondNumber),2);
        }
    }
}
