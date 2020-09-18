using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Program
{
    static class ShapeIDManager
    {
        // 一个给形状分配ID的类，采用静态字段，每调用构造方法生成一个形状，就会默认为其分配一个ID
        static string ID = "0000";

        public static string GetFlatShapeID()
        {
            int intID = int.Parse(ID) + 1;
            ID = intID.ToString().PadLeft(4, '0');

            return ID;
        }
    }

    public abstract class FlatShape
    {
        public string ID
        {
            get => ShapeIDManager.GetFlatShapeID();
        }

        public abstract string Type { get; }
        public abstract bool IsLegal();
        public abstract double Area { get; }
    }

    public class Rectangle : FlatShape
    {
        public override bool IsLegal()
        {
            if (length > 0 && width > 0)
            { return true; }
            else
            {
                throw new Exception();
            }
        }

        public Rectangle(double length, double width)
        {
            // 长方形的构造函数
            this.length = length;
            this.width = width;

            if (!IsLegal())
                this.length = this.width = 0;
        }

        public Rectangle(double sideLength)
        {
            this.length = this.width = sideLength;

            if (!IsLegal())
                this.length = this.width = 0;
        }

        public override string Type
        {
            get => "Rectangle";
        }

        public double Length
        {
            get => length;
            set
            {
                double reserve = length;
                length = value;
                if (!IsLegal())
                    this.length = reserve;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                double reserve = width;
                width = value;
                if (!IsLegal())
                    this.width = reserve;
            }
        }

        public override double Area
        {
            get => length * width;
        }


        double length;
        double width;
    }

    public class Square : Rectangle
    {
        public override bool IsLegal()
        {
            return base.IsLegal();
        }

        public override string Type
        {
            get => "Square";
        }

        public Square(double sideLength) : base(sideLength) { }
    }

    public class Triangle : FlatShape
    {
        public override bool IsLegal()
        {
            Array.Sort(sideArray);
            if (sideArray[0] > 0 && sideArray[0] + sideArray[1] > sideArray[2])
                return true;
            else
            {
                throw new Exception();
            }
        }

        public Triangle(double side1, double side2, double side3)
        {
            double[] sideArray = { side1, side2, side3 };
            this.sideArray = sideArray;

            if (!IsLegal())
                sideArray[0] = sideArray[1] = sideArray[2] = 0;
        }

        public override string Type
        {
            get => "Triangle";
        }

        public override double Area
        {
            get
            {
                double sum = 0;
                foreach (double side in sideArray)
                    sum += side;

                double p = sum / 2.0;

                double area = 1;
                foreach (double side in sideArray)
                    area *= (p - side);
                area = Math.Sqrt(p * area);

                return area;
            }
        }


        double[] sideArray = new double[3];
    }

    class AddAreasFactory
    {
        // 面积计算工厂函数
        public static double AddAreas(FlatShape[] shapes)
        {
            double sumArea = 0;
            foreach (FlatShape shape in shapes)
                sumArea += shape.Area;

            return sumArea;
        }
    }

    class Program
    {
        private enum AllShape
        {
            Rectangle,
            Square,
            Triangle
        }

        static Random getRandom()
        {
            Random ro = new Random(10);
            long tick = DateTime.Now.Ticks;

            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            // 由于Random以时间作为种子，故每次取完随机数暂停一段时间，确保取得的随机数重复性小
            Thread.Sleep(100);

            return ran;
        }

        static FlatShape GetShape()
        {
            // 随机取出一种形状，并赋予大小
            AllShape[] shapes = Enum.GetValues(typeof(AllShape)) as AllShape[];

            AllShape shape = shapes[getRandom().Next(0, shapes.Length)];

            double[] values = new double[3];

            // 在-10.0到100.0中取三个数
            for (int i = 0; i < 3; i++)
            {
                values[i] = getRandom().Next(-100, 1000) / 10.0;
            }

            FlatShape flatShape = null;
            switch (shape.ToString())
            {
                case "Rectangle":
                    flatShape = new Rectangle(values[0], values[1]);
                    break;
                case "Square":
                    flatShape = new Square(values[0]);
                    break;
                case "Triangle":
                    flatShape = new Triangle(values[0], values[1], values[2]);
                    break;
            }

            return flatShape;
        }

        static void Main(string[] args)
        {
            int shapeNumber = 10;
            int i = 0;
            FlatShape[] shapes = new FlatShape[shapeNumber];
            while (i < shapeNumber)
            {
                try
                {
                    FlatShape shape = GetShape();
                    Console.WriteLine($"Created a {shape.Type}, its ID is {shape.ID}, and its area is {shape.Area}.");

                    shapes[i] = shape;
                    i++;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Created an illegal shape.");
                }
            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"The added area is {AddAreasFactory.AddAreas(shapes)}.");
        }
    }
}

