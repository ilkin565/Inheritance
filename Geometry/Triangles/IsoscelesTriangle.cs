using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry.Triangles
{
    class IsoscelesTriangle : Triangle
    {
        double baseSide;
        double equalSide;

        public double BaseSide
        {
            get => baseSide;
            set => baseSide = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
        }

        public double EqualSide
        {
            get => equalSide;
            set => equalSide = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
        }

        public IsoscelesTriangle(double baseSide, double equalSide, int start_x, int start_y, int line_width, Color color)
            : base(start_x, start_y, line_width, color)
        {
            BaseSide = baseSide;
            EqualSide = equalSide;
        }

        public override double GetHeight()
        {
            return Math.Sqrt(EqualSide * EqualSide - (BaseSide * BaseSide) / 4);
        }

        public override double GetArea()
        {
            return BaseSide * GetHeight() / 2;
        }

        public override double GetPerimeter()
        {
            return BaseSide + 2 * EqualSide;
        }

        public override void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, LineWidth);
            Point[] vertex = new Point[]
            {
                new Point(StartX, StartY + (int)GetHeight()),
                new Point(StartX + (int)BaseSide, StartY + (int)GetHeight()),
                new Point(StartX + (int)BaseSide / 2, StartY)
            };
            e.Graphics.DrawPolygon(pen, vertex);
        }

        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine(GetType());
            Console.WriteLine($"Основание: {BaseSide}, Боковая сторона: {EqualSide}");
            Console.WriteLine($"Высота: {GetHeight():F2}");
            Console.WriteLine($"Площадь: {GetArea():F2}");
            Console.WriteLine($"Периметр: {GetPerimeter():F2}");
            Draw(e);
        }

        public override bool IsOutOfBounds(int screenWidth, int screenHeight)
        {
            return StartX < 0 ||
                   StartY < 0 ||
                   (StartX + BaseSide) > screenWidth ||
                   (StartY + GetHeight()) > screenHeight;
        }
    }
}