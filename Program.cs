using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    class Program
    {
        public const int ScreenW = 400;
        public const int ScreenH = 800;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Invaders"))
            {
                window.Closed += (s, e) => window.Close();
            }
        }
    }
}
