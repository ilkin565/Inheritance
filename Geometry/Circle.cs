﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
	class Circle : Shape, IHaveDiameter
	{
		double radius;
		public double Radius
		{
			get => radius;
			set => radius = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public Circle(double radius, int start_x, int start_y, int line_width, Color color)
			: base(start_x, start_y, line_width, color)
		{
			Radius = radius;
		}
		public double GetDiameter()
		{
			return Radius * 2;
		}
		public override double GetArea()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}
		public override double GetPerimeter()
		{
			return Math.PI * GetDiameter();
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color, LineWidth);
			e.Graphics.DrawEllipse(pen, StartX, StartY, (float)GetDiameter(), (float)GetDiameter());
		}
		public override void Info(PaintEventArgs e)
		{
            Console.WriteLine();
            Console.WriteLine(GetType());
            Console.WriteLine($"Радиус: {Radius}");
            Console.WriteLine($"Диаметр: {GetDiameter()}");
            Console.WriteLine($"Площадь: {GetArea():F2}");
            Console.WriteLine($"Периметр: {GetPerimeter():F2}");
            Draw(e);
        }
        public override bool IsOutOfBounds(int screenWidth, int screenHeight)
        {
            double diameter = GetDiameter();
            return StartX < 0 ||
                   StartY < 0 ||
                   (StartX + diameter) > screenWidth ||
                   (StartY + diameter) > screenHeight;
        }
    }
}