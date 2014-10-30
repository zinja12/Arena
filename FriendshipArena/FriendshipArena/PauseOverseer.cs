using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class PauseOverseer
    {
        public MenuItem resume_game;
        public MenuItem exit_game;

        private int menu_selection;

        private readonly TimeSpan intervalBetween;
        TimeSpan lastTime;

        public PauseOverseer() 
        {
            resume_game = new MenuItem(new Vector2(355, 300), "Resume", Color.White);
            exit_game = new MenuItem(new Vector2(355, 325), "Exit Game", Color.White);
            menu_selection = 0;

            intervalBetween = TimeSpan.FromMilliseconds(300);
        }

        public void Update(GameTime gameTime) 
        {
            if (menu_selection < 0)
                menu_selection = 0;

            if (menu_selection > 1)
                menu_selection = 1;

            if (Input.keyS || Input.LjoystickDown || Input.RjoystickDown) 
            {
                if ((lastTime + intervalBetween) < gameTime.TotalGameTime)
                {
                    menu_selection++;
                    lastTime = gameTime.TotalGameTime;
                }
                else
                {
                    //Do nothing
                    //Wait
                }
            }

            if (Input.keyW || Input.LjoystickUp || Input.RjoystickUp) 
            {
                if ((lastTime + intervalBetween) < gameTime.TotalGameTime)
                {
                    menu_selection--;
                    lastTime = gameTime.TotalGameTime;
                }
                else
                {
                    //Do nothing
                    //Wait
                }
            }

            if (Input.keyEnter || Input.buttonA) 
            {
                if (menu_selection == 0)
                    GameStates.pause_game = false;

                if (menu_selection == 1)
                    Constant.quit_game = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            Renderer.FillRectangle(spriteBatch, new Vector2(310, 300), 150, 110, Color.Black);
            Renderer.FillRectangle(spriteBatch, new Vector2(330, (menu_selection * 25) + 310), 15, 15, Color.White);

            resume_game.Draw(spriteBatch);
            exit_game.Draw(spriteBatch);
        }
    }
}
