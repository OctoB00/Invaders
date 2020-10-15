using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Program
    {
        public const int ScreenW = 400;
        public const int ScreenH = 800;
        static void Main(string[] args)
        {
            bool gamestart = true;
            using (var window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Invaders"))
            {
                window.Closed += (s, e) => window.Close();
                Clock frameclock = new Clock();
                Playership player = new Playership()
                {
                    //Velocity = new Vector2f(0, 0),
                    Position = new Vector2f(ScreenW / 2, ScreenH / 2)
                };
                Game game = new Game(window);
                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    window.Clear(new Color(0, 0, 0));
                    float deltaTime = frameclock.Restart().AsSeconds();
                    game.RenderAll(window);
                    if (gamestart)
                    {
                        game.Spawn(player);
                        gamestart = false;
                    }
                    game.UpdateAll(deltaTime);

                    window.Display();
                }
            }
        }
    }
}
