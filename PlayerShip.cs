using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class PlayerShip : Entity
    {
        private readonly Sprite sprite;
        public PlayerShip()
        {
            sprite = new Sprite();
        }
        public override void Load(Textures textures)
        {
            sprite.Texture = textures.GetTexture("Playership.png");
            sprite.Origin = (Vector2f)sprite.Texture.Size * 0.5f;
        }
        public Vector2f Velocity
        {
            get;
            set;
        }
        public override Vector2f Position 
        { 
            get => sprite.Position; 
            set => sprite.Position = value; 
        }
    }
}
