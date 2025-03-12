using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    public static class ShapeFactory
    {
        /// 创建形状对象
        /// shapeType: 1-Rectangle, 2-Square, 3-Triangle
        /// param1、param2、param3 分别表示对应形状的边长或尺寸（对于正方形只需要 param1，对于长方形需要 param1 和 param2，对于三角形需要三边）        
        public static Shape CreateShape(int shapeType, double param1, double param2=0, double param3 = 0)
        {
            switch (shapeType)
            {
                case 1:
                    return new Rectangle(param1, param2);
                case 2:
                    return new Square(param1);
                case 3:
                    return new Triangle(param1, param2, param3);
                default:
                    return null;
            }
        }
    }
}

