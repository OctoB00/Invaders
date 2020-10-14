using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Game
    {
        private Textures textures;
        private List<Entity> entities;
        private List<Entity> spawnList;
        private List<Entity> hitList;
        private Window w;
        
        public Game(Window w)
        {
            textures = new Textures();
            entities = new List<Entity>();
            spawnList = new List<Entity>();
            hitList = new List<Entity>();
            this.w = w;
        }
        public void Spawn(Entity entity)
        {
            spawnList.Add(entity);
            entity.Load(textures);
            entity.OnSpawn(w)
        }
        public void Kill(Entity entity)
        {
            hitList.Add(entity);
        }
        public void Clear()
        {
            entities.Clear();
            spawnList.Clear();
            hitList.Clear();
        }
        public void UpdateAll(float deltaTime)
        {
            foreach (Entity entity in spawnList)
            {
                entities.Add(entity);
            }
            spawnList.Clear();
            foreach (Entity entity in entities)
            {
                entity.Update(this, deltaTime);
            }
            //foreach (Entity entity in hitList)
            //{
            //    entities.Remove(entity);
            //}
        }
        public void RenderAll(RenderTarget window)
        {
            foreach (Entity entity in entities)
            {
                entity.Render(window);
            }
        }
    }
}
