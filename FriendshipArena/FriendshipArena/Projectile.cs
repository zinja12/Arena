using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Projectile
    {
        public Vector2 position;
        public bool isVisible;

        private String direction;

        public Projectile(Vector2 position, String direction) 
        {
            this.position = position;
            this.direction = direction;
        }

        public void Update(GameTime gameTime) 
        {
            if (isVisible)
            {
                if (direction == "TopRight")
                {
                    position.X += 1;
                    position.Y -= 1;
                }

                if (direction == "BottomRight")
                {
                    position.X += 1;
                    position.Y += 1;
                }

                if (direction == "BottomLeft")
                {
                    position.X -= 1;
                    position.Y += 1;
                }

                if (direction == "TopLeft")
                {
                    position.X -= 1;
                    position.Y -= 1;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            Renderer.FillRectangle(spriteBatch, position, 5, 5, Color.Pink);
        }
    }
}
