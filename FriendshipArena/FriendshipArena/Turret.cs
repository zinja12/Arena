using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Turret
    {
        public Vector2 position;
        public List<Projectile> projectiles;

        public Turret() 
        {
            this.position = Maths.RandomPosition();
            projectiles = new List<Projectile>();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(spriteBatch);
            }
        }
    }
}
