using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Calculator
    {
        public enum Status
        {
            Number1,
            Number2,
        }
        public string number1, number2,op;
        public string display;
        public Status status;
        public Calculator()
        {
            status = Status.Number1;
            number1 = "";
            number2 = "";
            op = "";
            display = "";
        }
        public double Calculate()
        {
            double result = 0;
            switch (op)
            {
                case "+":
                    result = double.Parse(number1) + double.Parse(number2);
                    break;
                case "-":
                    result = double.Parse(number1) - double.Parse(number2);
                    break;
                case "*":
                    result = double.Parse(number1) * double.Parse(number2);
                    break;
                case "/":
                    if (double.Parse(number2) == 0)
                        throw new ArgumentException("除数不能为零");
                    result = double.Parse(number1) / double.Parse(number2);
                    break;
            }
            return result;
        }
        public void flush()
        {
            display =number1=number2=op= "";
            status = Status.Number1;
        }


    }
}
