using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Textures
    {
        private Dictionary<string, Texture> textures;

        public Textures()
        {
            textures = new Dictionary<string, Texture>();
        }
        public Texture GetTexture(string name)
        {
            foreach (KeyValuePair<string, Texture> pair in textures)
            {
                if (name == pair.Key)
                {
                    return pair.Value;
                }
            }
            Texture texture = new Texture(name);
            textures.Add(name, texture);
            return texture;
        }
    }
}