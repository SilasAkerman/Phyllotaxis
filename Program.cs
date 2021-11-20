using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace Phyllotaxis
{
    class Program
    {
        const int WIDTH = 600;
        const int HEIGHT = 600;

        static List<Vector2> points = new List<Vector2>();

        static int amount;
        static double scalar;
        static double angle;

        static Slider amountSlider = new Slider()
        {
            X = 10,
            Y = 500,
            Width = 150,
            Minimum = 1,
            Maximum = 1000,
            Increment = 1,
            Placement = 100
        };
        static Slider scalarSlider = new Slider()
        {
            X = 210,
            Y = 500,
            Width = 150,
            Minimum = 5,
            Maximum = 20,
            Increment = 0.5,
            Placement = 10
        };
        static Slider angleSlider = new Slider()
        {
            X = 410,
            Y = 500,
            Width = 150,
            Minimum = 1,
            Maximum = 360,
            Increment = 0.5,
            Placement = 137.5
        };

        static void Main(string[] args)
        {
            Raylib.InitWindow(WIDTH, HEIGHT, "Phyllotaxis");

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Display();
            }

            Raylib.CloseWindow();
        }

        static void Update()
        {
            amount = (int)amountSlider.Value;
            scalar = scalarSlider.Value;
            angle = angleSlider.Value;

            points.Clear();
            for (int i = 0; i < amount; i++)
            {
                double a = i * angle;
                double r = scalar * Math.Sqrt(i);
                double x = r * Math.Cos(a);
                double y = r * Math.Sin(a);
                points.Add(new Vector2((float)x + WIDTH/2, (float)y + HEIGHT/2));
            }

            amountSlider.Update();
            scalarSlider.Update();
            angleSlider.Update();
        }

        static void Display()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            foreach (Vector2 point in points)
            {
                Raylib.DrawCircleV(point, 3, Color.WHITE);
                Raylib.DrawCircleLines((int)point.X, (int)point.Y, 3, Color.BLACK);
            }

            amountSlider.Display();
            scalarSlider.Display();
            angleSlider.Display();
            Raylib.EndDrawing();
        }
    }
}
