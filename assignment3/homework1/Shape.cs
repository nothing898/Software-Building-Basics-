using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    // 抽象基类：形状
    public abstract class Shape
    {
        // 抽象属性，判断形状是否合法
        public abstract bool IsValid { get; }
        // 抽象方法，计算面积
        public abstract double CalculateArea();
        public abstract string Type { get; }
    }
}
