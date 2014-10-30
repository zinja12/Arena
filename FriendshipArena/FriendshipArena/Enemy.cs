using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Enemy
    {
        public Vector2 position;
        public Rectangle collision_rect;
        public bool isVisible;

        private float speed;
        private Random rand;
        private bool targetChosen;
        private int target;

        Animation animation;


        public Enemy(Vector2 position) 
        {
            this.position = position;
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.enemy_Size, Constant.enemy_Size);
            speed = 0.9f;
            targetChosen = false;
            isVisible = true;

            animation = new Animation(150f, 1, 1 * Constant.enemy_Size, 0 * Constant.enemy_Size, Constant.enemy_Size, Constant.enemy_Size);
        }

        public void Update(GameTime gameTime) 
        {
            collision_rect = new Rectangle((int)position.X, (int)position.Y, Constant.enemy_Size, Constant.enemy_Size);

            chooseTarget();

            if (target == 1) 
            {
                Vector2 direction = (Players.position_1 - position);
                direction.Normalize();

                position += direction * speed;

                if (position.X <= Players.position_1.X)
                {
                    animation.Y = 0 * Constant.enemy_Size;
                }
                else if (position.X > Players.position_1.X)
                {
                    animation.Y = 1 * Constant.enemy_Size;
                }
            }

            if (target == 2)
            {
                Vector2 direction = (Players.position_2 - position);
                direction.Normalize();

                position += direction * speed;

                if (position.X <= Players.position_2.X)
                {
                    animation.Y = 0 * Constant.enemy_Size;
                }
                else if (position.X > Players.position_2.X) 
                {
                    animation.Y = 1 * Constant.enemy_Size;
                }
            }

            if (collision_rect.Contains(new Point((int)Players.intermediatePoint.X, (int)Players.intermediatePoint.Y)) || collision_rect.Contains(new Point((int)Players.intermediatePoint1.X, (int)Players.intermediatePoint1.Y)) || collision_rect.Contains(new Point((int)Players.intermediatePoint2.X, (int)Players.intermediatePoint2.Y))) 
            {
                isVisible = false;
            }

            //Player Collisions

            //Take away health in the case of a collision
            if (collision_rect.Intersects(Players.player1_collision_rect))
                Players.health_1--;
            else if (collision_rect.Intersects(Players.player2_collision_rect))
                Players.health_2--;

            //Player 1
            if (collision_rect.Contains(new Point((int)(Players.position_1.X), (int)(Players.position_1.Y + (Constant.player_Size / 2)))))
                Players.position_1.X++;
            if (collision_rect.Contains(new Point((int)(Players.position_1.X + (Constant.player_Size / 2)), (int)(Players.position_1.Y))))
                Players.position_1.Y++;
            if (collision_rect.Contains(new Point((int)(Players.position_1.X + Constant.player_Size), (int)(Players.position_1.Y + (Constant.player_Size / 2)))))
                Players.position_1.X--;
            if (collision_rect.Contains(new Point((int)(Players.position_1.X + (Constant.player_Size / 2)), (int)(Players.position_1.X + Constant.player_Size))))
                Players.position_1.Y--;

            //Player 2
            if (collision_rect.Contains(new Point((int)(Players.position_2.X), (int)(Players.position_2.Y + (Constant.player_Size / 2)))))
                Players.position_2.X++;
            if (collision_rect.Contains(new Point((int)(Players.position_2.X + (Constant.player_Size / 2)), (int)(Players.position_2.Y))))
                Players.position_2.Y++;
            if (collision_rect.Contains(new Point((int)(Players.position_2.X + Constant.player_Size), (int)(Players.position_2.Y + (Constant.player_Size / 2)))))
                Players.position_2.X--;
            if (collision_rect.Contains(new Point((int)(Players.position_2.X + (Constant.player_Size / 2)), (int)(Players.position_2.X + Constant.player_Size))))
                Players.position_2.Y--;

            animation.Update(gameTime);
        }

        public void chooseTarget() 
        {
            if (!targetChosen) 
            {
                rand = new Random();
                target = rand.Next(1, 3);
                targetChosen = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(Constant.enemy_SpriteSheet, position, animation.source_rect, Color.White);
        }
    }
}
