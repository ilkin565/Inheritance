using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometry.Triangles;

namespace Geometry
{
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        static void Main(string[] args)
        {
            IntPtr hwnd = GetConsoleWindow();

            GetClientRect(hwnd, out RECT rect);
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            using (Graphics graphics = Graphics.FromHwnd(hwnd))
            {
                PaintEventArgs e = new PaintEventArgs(
                    graphics,
                    new System.Drawing.Rectangle(0, 0, width, height));

                Shape[] shapes = new Shape[]
                {
                    new Square(100, 200, 300, 3, Color.Red),
                    new Rectangle(100, 200, 320, 200, 3, Color.Blue),
                    new Circle(100, 420, 0, 3, Color.Green),
                    new EquilateralTriangle(100, 100, 320, 3, Color.Orange),
                    new RightTriangle(80, 60, 50, 50, 2, Color.Violet),
                    new IsoscelesTriangle(100, 80, 200, 50, 2, Color.Yellow)
                };

                foreach (Shape shape in shapes)
                {
                    if (!shape.IsOutOfBounds(width, height))
                    {
                        shape.Draw(e);
                    }
                    else
                    {
                        Console.WriteLine($"{shape.GetType().Name} выходит за границы!");
                    }
                }
            }

            Console.WriteLine("Рисование завершено. Нажмите Enter...");
            Console.ReadLine();
        }
    }
}