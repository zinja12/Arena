﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Renderer
    {
        public static float lineAngle;
        public static float lineLength;

        public static void DrawALine(SpriteBatch batch, Texture2D blank,
              float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);
            lineAngle = angle;
            lineLength = length;

            batch.Draw(blank, point1, null, color,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }

        public static void FillRectangle(SpriteBatch spriteBatch, Vector2 rect_position, int width, int height, Color color) 
        {
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, width, height);

            Color[] color_data = new Color[width * height];
            for (int i = 0; i < color_data.Length; i++)
                color_data[i] = color;
            rect.SetData(color_data);

            Vector2 position = rect_position;
            spriteBatch.Draw(rect, position, Color.White);
        }
    }
}
