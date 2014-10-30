using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Power_Up
    {
        public Vector2 position;
        public int power_upSort;
        
        private Random rnd;

        public Power_Up() 
        {
            position = Maths.RandomPosition();
            rnd = new Random();
            this.power_upSort = rnd.Next(1, 3);
        }

        public void Update(GameTime gameTime) 
        {
            //Speed
            if (power_upSort == 1) 
            {
                Players.power_upSort = power_upSort;
            }
            //Ghost
            if (power_upSort == 2) 
            {
                Players.power_upSort = power_upSort;
            }
            //Others will be added
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            if (power_upSort == 1) { }
            if (power_upSort == 2) { }
        }
    }
}
