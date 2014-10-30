using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Door
    {
        public Vector2 position;
        public Rectangle collision_rect;
        public bool isVisible;
        public List<Enemy> enemies;

        private Random rnd;

        private readonly TimeSpan intervalBetween;
        TimeSpan lastTime;

        public Door() 
        {
            rnd = new Random();
            position = Maths.RandomPosition();
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.block_Size, Constant.block_Size);
            isVisible = true;
            enemies = new List<Enemy>();
            intervalBetween = TimeSpan.FromMilliseconds(5000);
        }

        public void Update(GameTime gameTime) 
        {
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.block_Size, Constant.block_Size);

            if (collision_rect.Contains(new Point((int)Players.intermediatePoint.X, (int)Players.intermediatePoint.Y)) || collision_rect.Contains(new Point((int)Players.intermediatePoint1.X, (int)Players.intermediatePoint1.Y)) || collision_rect.Contains(new Point((int)Players.intermediatePoint2.X, (int)Players.intermediatePoint2.Y)))
            {
                isVisible = false;
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(gameTime);

                if (!enemies[i].isVisible)
                {
                    SurvivalOverseer.enemiesDefeated++;
                    enemies.RemoveAt(i);
                }
            }

            spawn_enemies(gameTime);
        }

        public void spawn_enemies(GameTime gameTime) 
        {
            if ((lastTime + intervalBetween) < gameTime.TotalGameTime)
            {
                enemies.Add(new Enemy(position));
                lastTime = gameTime.TotalGameTime;
            }
            else
            {
                //Do nothing
                //Wait to spawn another enemy
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(Constant.texture_SpriteSheet, position, new Rectangle(0 * Constant.block_Size, 3 * Constant.block_Size, Constant.block_Size, Constant.block_Size), Color.White);

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }
        }
    }
}
