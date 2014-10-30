using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Block
    {
        public Vector2 position;
        public Rectangle collision_rect;
        public Rectangle draw_rect;
        public int[] id = { -1, -1 };

        public Block(Vector2 position, int[] id) 
        {
            this.position = position;
            this.id = id;
            draw_rect = new Rectangle(id[0] * Constant.block_Size, id[1] * Constant.block_Size, Constant.block_Size, Constant.block_Size);
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.block_Size, Constant.block_Size);
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(Constant.texture_SpriteSheet, position, draw_rect, Color.White);
        }
    }
}
