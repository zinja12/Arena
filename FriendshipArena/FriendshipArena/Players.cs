using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Players
    {
        public static Vector2 position_1;
        public static Vector2 position_2;
        public static Rectangle player1_collision_rect;
        public static Rectangle player2_collision_rect;
        public static Vector2 intermediatePoint;
        public static Vector2 intermediatePoint1;
        public static Vector2 intermediatePoint2;
        public static int health_1;
        public static int health_2;
        public static int power_upSort;
        public static bool alive;

        private Vector2 vel_1;
        private Vector2 vel_2;
        private bool moving_1X;
        private bool moving_2X;

        Animation animation_1;
        Animation animation_2;

        public Players(Vector2 position_1, Vector2 position_2) 
        {
            Players.position_1 = position_1;
            Players.position_2 = position_2;
            Players.player1_collision_rect = new Rectangle((int)position_1.X, (int)position_1.Y, Constant.player_Size, Constant.player_Size);
            Players.player2_collision_rect = new Rectangle((int)position_2.X, (int)position_2.Y, Constant.player_Size, Constant.player_Size);
            intermediatePoint = Maths.IntermediatePoint(new Vector2(position_1.X + Constant.player_Size, position_1.Y + Constant.player_Size), new Vector2(position_2.X + Constant.player_Size, position_2.Y + Constant.player_Size), 0.5f);
            intermediatePoint1 = Maths.IntermediatePoint(new Vector2(position_1.X + Constant.player_Size, position_1.Y + Constant.player_Size), intermediatePoint, 0.5f);
            intermediatePoint2 = Maths.IntermediatePoint(intermediatePoint, new Vector2(position_2.X + Constant.player_Size, position_2.Y + Constant.player_Size), 0.5f);
            health_1 = 20;
            health_2 = 20;
            power_upSort = 0;
            alive = true;

            moving_1X = false;
            moving_2X = false;

            animation_1 = new Animation(150f, 2, 1 * Constant.player_Size, 0 * Constant.player_Size, Constant.player_Size, Constant.player_Size);
            animation_2 = new Animation(150f, 2, 1 * Constant.player_Size, 0 * Constant.player_Size, Constant.player_Size, Constant.player_Size);
        }

        public void Update(GameTime gameTime) 
        {
            Players.player1_collision_rect = new Rectangle((int)position_1.X, (int)position_1.Y, Constant.player_Size, Constant.player_Size);
            Players.player2_collision_rect = new Rectangle((int)position_2.X, (int)position_2.Y, Constant.player_Size, Constant.player_Size);

            intermediatePoint = Maths.IntermediatePoint(new Vector2(position_1.X + Constant.player_Size / 2, position_1.Y + Constant.player_Size / 2), new Vector2(position_2.X + Constant.player_Size / 2, position_2.Y + Constant.player_Size / 2), 0.5f);
            intermediatePoint1 = Maths.IntermediatePoint(new Vector2(position_1.X + Constant.player_Size / 2, position_1.Y + Constant.player_Size / 2), intermediatePoint, 0.5f);
            intermediatePoint2 = Maths.IntermediatePoint(intermediatePoint, new Vector2(position_2.X + Constant.player_Size / 2, position_2.Y + Constant.player_Size / 2), 0.5f);

            if (Input.keyW || Input.LjoystickUp) 
            {
                vel_1.Y = -1;
            }
            else if (Input.keyS || Input.LjoystickDown)
            {
                vel_1.Y = 1;
            }
            else 
            {
                vel_1.Y = 0;
            }

            if (Input.keyA || Input.LjoystickLeft)
            {
                vel_1.X = -1;
                animation_1.Y = 1 * Constant.player_Size;
                moving_1X = true;
            }
            else if (Input.keyD || Input.LjoystickRight)
            {
                vel_1.X = 1;
                animation_1.Y = 0 * Constant.player_Size;
                moving_1X = true;
            }
            else
            {
                vel_1.X = 0;
                moving_1X = false;
            } 
            
            if (Input.keyUp || Input.RjoystickUp)
            {
                vel_2.Y = -1;
            }
            else if (Input.keyDown || Input.RjoystickDown)
            {
                vel_2.Y = 1;
            }
            else
            {
                vel_2.Y = 0;
            }

            if (Input.keyLeft || Input.RjoystickLeft)
            {
                vel_2.X = -1;
                animation_2.Y = 1 * Constant.player_Size;
                moving_2X = true;
            }
            else if (Input.keyRight || Input.RjoystickRight)
            {
                vel_2.X = 1;
                animation_2.Y = 0 * Constant.player_Size;
                moving_2X = true;
            }
            else
            {
                vel_2.X = 0;
                moving_2X = false;
            }

            if (Vector2.Distance(position_1, position_2) > 150) 
            {
                Vector2 direction1 = (position_1 - position_2);
                direction1.Normalize();
                Vector2 direction2 = (position_2 - position_1);
                direction2.Normalize();

                position_1 -= direction1 * 1.5f;
                position_2 -= direction2 * 1.5f;
            }

            position_1 += vel_1;
            position_2 += vel_2;

            //Health
            if (health_1 == 0 || health_2 == 0) 
            {
                alive = false;
            }

            animation_1.Update(gameTime);
            animation_2.Update(gameTime);

            Console.WriteLine("health_1: " + health_1);
            Console.WriteLine("health_2: " + health_2);
        }

        public void Draw(SpriteBatch spritebatch) 
        {
            //Replace the players textures with squares
            //Clean and simple squares that rotate when you move

            //If changes are made to to drawing code make sure to change the player_Size in the Constant class

            Renderer.DrawALine(spritebatch, Constant.pixel_SPR, 1, Color.Black, new Vector2(position_1.X + Constant.player_Size / 2, position_1.Y + Constant.player_Size / 2), new Vector2(position_2.X + Constant.player_Size / 2, position_2.Y + Constant.player_Size / 2));

            if (moving_1X)
            {
                spritebatch.Draw(Constant.players_SpriteSheet, position_1, animation_1.source_rect, Color.Red);
            }
            else 
            {
                spritebatch.Draw(Constant.players_SpriteSheet, position_1, new Rectangle(0 * Constant.player_Size, 0 * Constant.player_Size, Constant.player_Size, Constant.player_Size), Color.Red);
            }

            if (moving_2X)
            {
                spritebatch.Draw(Constant.players_SpriteSheet, position_2, animation_2.source_rect, Color.CornflowerBlue);
            }
            else 
            {
                spritebatch.Draw(Constant.players_SpriteSheet, position_2, new Rectangle(0 * Constant.player_Size, 0 * Constant.player_Size, Constant.player_Size, Constant.player_Size), Color.CornflowerBlue);
            }
        }
    }
}
