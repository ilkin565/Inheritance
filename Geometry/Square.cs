using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
    class Square : Rectangle
    {
        public Square(double side, int start_x, int start_y, int line_width, Color color)
            : base(side, side, start_x, start_y, line_width, color) { }

        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine(GetType());
            Console.WriteLine($"Длина стороны: {Width}");
            Console.WriteLine($"Диагональ: {GetDiagonal():F2}");
            Console.WriteLine($"Площадь: {GetArea():F2}");
            Console.WriteLine($"Периметр: {GetPerimeter():F2}");
            Draw(e);
        }
        public override bool IsOutOfBounds(int screenWidth, int screenHeight)
        {
            return base.IsOutOfBounds(screenWidth, screenHeight);
        }
    }
}