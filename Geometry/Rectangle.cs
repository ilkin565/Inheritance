﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
	class Rectangle : Shape, IHaveDiagonal
	{
		double width;
		double height;
		public double Width
		{
			get => width;
			set => width = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public double Height
		{
			get => height;
			set => height = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public Rectangle(double width, double height, int start_x, int start_y, int line_width, Color color)
			: base(start_x, start_y, line_width, color)
		{
			Width = width;
			Height = height;
		}
		public double GetDiagonal()
		{
			return Math.Sqrt(Width * Width + Height * Height);
		}
		public override double GetArea()
		{
			return Width * Height;
		}
		public override double GetPerimeter()
		{
			return (Width + Height) * 2;
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawRectangle(pen, StartX, StartY, (float)Width, (float)Height);
		}
		public override void Info(PaintEventArgs e)
		{
            Console.WriteLine();
            Console.WriteLine(GetType());
            Console.WriteLine($"Ширина: {Width}, Высота: {Height}");
            Console.WriteLine($"Диагональ: {GetDiagonal():F2}");
            Console.WriteLine($"Площадь: {GetArea():F2}");
            Console.WriteLine($"Периметр: {GetPerimeter():F2}");
            Draw(e);
        }
        public override bool IsOutOfBounds(int screenWidth, int screenHeight)
        {
            return StartX < 0 ||
                   StartY < 0 ||
                   (StartX + Width) > screenWidth ||
                   (StartY + Height) > screenHeight;
        }
    }
}