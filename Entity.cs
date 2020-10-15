using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Entity
    {
        public virtual void Load(Textures textures)
        {

        }
        public virtual void OnSpawn(Window w)
        {

        }
        public virtual void OnDespawn(Window w)
        {

        }
        public virtual void Update(Game game, float deltaTime)
        {

        }
        public virtual void Render(RenderTarget target)
        {

        }
        public virtual void Move(float speed, float deltaTime)
        {

        }
        //public virtual void CollideWith(Scene scene, Entity other)
        //{

        //}
        public virtual Vector2f Position { get; set; }
        public virtual float Radius { get; }
    }
}
