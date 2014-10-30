using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Animation
    {
        public Rectangle source_rect;
        public int X;
        public int Y;
        public int rectWidth;
        public int rectHeight;
        public int frameCount;

        float elapsed;
        float delay;
        int frames;

        public Animation(float delay, int frameCount, int X, int Y, int rectWidth, int rectHeight)
        {
            this.delay = delay;
            this.frameCount = frameCount;
            this.X = X;
            this.Y = Y;
            this.rectWidth = rectWidth;
            this.rectHeight = rectHeight;
            frames = 0;
        }

        public void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= delay)
            {
                if (frames >= frameCount)
                    frames = 0;
                else
                    frames++;

                elapsed = 0;
            }

            source_rect = new Rectangle(X + frames * rectWidth, Y, rectHeight, rectWidth);
        }
    }
}
