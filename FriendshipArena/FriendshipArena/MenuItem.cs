using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class MenuItem
    {
        public Vector2 position;
        public Rectangle collision_rect;

        private string text;
        private Color color;

        public MenuItem(Vector2 position, string text, Color color) 
        {
            this.position = position;
            this.text = text;
            this.color = color;
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(Constant.lilyUPCFont, text, position, color);
        }
    }
}
