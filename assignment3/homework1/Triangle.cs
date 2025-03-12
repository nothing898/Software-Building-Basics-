using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        // 判断三角形合法性：各边大于0且满足三角不等式
        public override string Type => "Triangle";
        public override bool IsValid =>
            A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A);
        public override double CalculateArea()
        {
            if (!IsValid)
                return 0;
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public override string ToString() => $"{Type,-10} (A={A:F2}, B={B:F2}, C={C:F2})";
    }
}
