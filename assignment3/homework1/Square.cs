using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Square : Shape
    {
        public double Side { get; set; }
        public Square(double side)
        {
            Side = side;
        }
        public override string Type=> "Square";
        public override bool IsValid => Side > 0;
        public override double CalculateArea() => IsValid ? Side * Side : 0;
        public override string ToString() => $"{Type,-10} (Side={Side:F2})";
    }
}
