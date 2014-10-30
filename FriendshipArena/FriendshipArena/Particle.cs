using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Particle
    {
        public Vector2 position;

        public Particle(Vector2 position) 
        {
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            Renderer.FillRectangle(spriteBatch, position, 3, 3, Color.Pink);
        }
    }
}
