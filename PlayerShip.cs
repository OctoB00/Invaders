using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Playership : Entity
    {
        private readonly Sprite sprite;
        private bool moveRight, moveLeft, moveUp, moveDown;
        private Vector2f Direction;
        private Vector2f newPosition;
        private float speed = 250;
        public Playership()
        {
            sprite = new Sprite();
        }
        public override void Load(Textures textures)
        {
            sprite.Texture = textures.GetTexture("Playership.png");
            sprite.Origin = (Vector2f)sprite.Texture.Size * 0.5f;
        }
        //public Vector2f Velocity
        //{
        //    get;
        //    set;
        //}
        public override Vector2f Position
        {
            get => sprite.Position;
            set => sprite.Position = value;
        }
        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Left: moveLeft = true; break;
                case Keyboard.Key.Right: moveRight = true; break;
                case Keyboard.Key.Up: moveUp = true; break;
                case Keyboard.Key.Down: moveDown = true; break;
            }
        }
        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Left: moveLeft = false; break;
                case Keyboard.Key.Right: moveRight = false; break;
                case Keyboard.Key.Up: moveUp = false; break;
                case Keyboard.Key.Down: moveDown = false; break;
            }
        }
        public override void OnSpawn(Window w)
        {
            w.KeyPressed += OnKeyPressed;
            w.KeyReleased += OnKeyReleased;
        }
        public override void OnDespawn(Window w)
        {
            w.KeyPressed -= OnKeyPressed;
            w.KeyReleased -= OnKeyReleased;
        }
        //public override void Move(float speed, float deltaTime)
        //{
        //    newPosition = sprite.Position + Direction * (speed * deltaTime);
        //}
        public override void Update(Game game, float deltaTime)
        {
            newPosition = sprite.Position + Direction * (speed * deltaTime);
            if (moveLeft)
            {
                Direction = new Vector2f(-1, 0);
            }
            else if (moveRight)
            {
                Direction = new Vector2f(1, 0);
            }
            else if (moveUp)
            {
                Direction = new Vector2f(0, -1);
            }
            else if (moveDown)
            {
                Direction = new Vector2f(0, 1);
            }
            else
            {
                Direction = new Vector2f(0, 0);
            }
            if (newPosition.Y + sprite.Origin.Y > Program.ScreenH || newPosition.Y - sprite.Origin.Y < 1)
            {
                Direction.Y = 0;
            }
            else if (newPosition.X + sprite.Origin.X > Program.ScreenW || newPosition.X - sprite.Origin.X < 1)
            {
                Direction.X = 0;
            }
            else
            {
                sprite.Position = newPosition;
            }
        }
        public override void Render(RenderTarget target)
        {
            sprite.Rotation = -90;
            target.Draw(sprite);
        }
    }
}
