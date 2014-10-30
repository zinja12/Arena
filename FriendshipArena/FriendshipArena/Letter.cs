using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Letter
    {
        public Vector2 position;
        public Rectangle collision_rect;
        public bool isVisible;

        public Letter(Vector2 position) 
        {
            this.position = position;
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.block_Size, Constant.block_Size);
            isVisible = true;
        }

        public void Update(GameTime gameTime) 
        {
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.block_Size, Constant.block_Size);

            if (collision_rect.Intersects(Players.player1_collision_rect) || collision_rect.Intersects(Players.player2_collision_rect)) 
            {
                Console.WriteLine("Collision!");
                isVisible = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(Constant.texture_SpriteSheet, position, new Rectangle(2 * Constant.block_Size, 2 * Constant.block_Size, Constant.block_Size, Constant.block_Size), Color.White);
        }
    }
}
