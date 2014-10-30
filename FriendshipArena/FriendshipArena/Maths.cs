using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Maths
    {
        public static Vector2 IntermediatePoint(Vector2 a, Vector2 b, float t) 
        {
            Vector2 delta = b - a;

            float distance = delta.Length();

            if (distance == 0.0f)
            {
                return a;
            }
            else 
            {
                Vector2 direction = delta / distance;

                return a + direction * (distance * t);
            }
        }

        public static Vector2 RandomPosition() 
        {
            Random rnd = new Random();
            Vector2 position = new Vector2((float)rnd.Next(0, 751), (float)rnd.Next(0, 441));
            return position;
        }
    }
}
