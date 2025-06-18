using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry.Triangles
{
    class RightTriangle : Triangle
    {
        double sideA;
        double sideB;

        public double SideA
        {
            get => sideA;
            set => sideA = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
        }

        public double SideB
        {
            get => sideB;
            set => sideB = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
        }

        public RightTriangle(double sideA, double sideB, int start_x, int start_y, int line_width, Color color)
            : base(start_x, start_y, line_width, color)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public override double GetHeight()
        {
            return SideB;
        }

        public override double GetArea()
        {
            return SideA * SideB / 2;
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + Math.Sqrt(SideA * SideA + SideB * SideB);
        }

        public override void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, LineWidth);
            Point[] vertex = new Point[]
            {
                new Point(StartX, StartY),
                new Point(StartX, StartY + (int)SideB),
                new Point(StartX + (int)SideA, StartY + (int)SideB)
            };
            e.Graphics.DrawPolygon(pen, vertex);
        }

        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine(GetType());
            Console.WriteLine($"Катет 1: {SideA}, Катет 2: {SideB}");
            Console.WriteLine($"Гипотенуза: {Math.Sqrt(SideA * SideA + SideB * SideB):F2}");
            Console.WriteLine($"Площадь: {GetArea():F2}");
            Console.WriteLine($"Периметр: {GetPerimeter():F2}");
            Draw(e);
        }

        public override bool IsOutOfBounds(int screenWidth, int screenHeight)
        {
            return StartX < 0 ||
                   StartY < 0 ||
                   (StartX + SideA) > screenWidth ||
                   (StartY + SideB) > screenHeight;
        }
    }
}