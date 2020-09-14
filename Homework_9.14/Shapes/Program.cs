using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
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
        public abstract double Perimeter { get; }
    }

    public class Rectangle : FlatShape
    {
        public override bool IsLegal()
        {
            if (length > 0 && width > 0)
                return true;
            else
            {
                throw new Exception();
                return false;
            }
        }
        public Rectangle(double length, double width)
        {
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
        public override double Perimeter
        {
            get => 2 * (length + width);
        }
        double length;
        double width;
    }

    public class Square:Rectangle
    {
        public override bool IsLegal()
        {
            return base.IsLegal();
        }
        public Square(double sidelength) : base(sidelength) { }
        public override string Type
        {
            get => "Square";
        }
    }
    public class Triangle:FlatShape
    {
        public override bool IsLegal()
        {
            throw new NotImplementedException();
        }
        public Triangle()
        {

        }
        public override string Type => throw new NotImplementedException();
        public override double Area => throw new NotImplementedException();
        public override double Perimeter => throw new NotImplementedException();

    }
    class Program
    {
        
        static void Main(string[] args)
        {

        }
    }
}
