using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class TitleOverseer
    {
        //Main title
        public MenuItem playItem;
        public MenuItem optionsItem;
        public MenuItem credits;
        public MenuItem exit;

        //Play subtitle
        public MenuItem storyItem;
        public MenuItem survivalItem;

        private int title_state;
        private int menu_selection;
        private int playMenu_selection;

        private readonly TimeSpan intervalBetween;
        TimeSpan lastTime;

        public TitleOverseer() 
        {
            playItem = new MenuItem(new Vector2(355, 300), "PLAY", Color.White);
            optionsItem = new MenuItem(new Vector2(355, 325), "OPTIONS", Color.White);
            credits = new MenuItem(new Vector2(355, 350), "CREDITS", Color.White);
            exit = new MenuItem(new Vector2(355, 375), "EXIT", Color.White);

            storyItem = new MenuItem(new Vector2(355, 300), "STORY", Color.White);
            survivalItem = new MenuItem(new Vector2(355, 325), "SURVIVAL", Color.White);

            menu_selection = 0;
            title_state = 1;

            intervalBetween = TimeSpan.FromMilliseconds(300);
        }

        public void Update(GameTime gameTime) 
        {
            //Update Title Screen
            //Take user input
            //Switch gamestate to appropriate state
            //Logic for rotation for effect

            if (title_state == 1)
            {
                if (menu_selection < 0)
                    menu_selection = 0;

                if (menu_selection > 3)
                    menu_selection = 3;

                if (Input.keyDown || Input.LjoystickDown || Input.RjoystickDown)
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

                if (Input.keyUp || Input.LjoystickUp || Input.RjoystickUp)
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

                if (Input.keyEnter || Input.buttonA || Input.keyRight)
                {
                    if (menu_selection == 0)
                    {
                        menu_selection = 0;
                        title_state = 2;
                    }

                    if (menu_selection == 3)
                    {
                        Constant.quit_game = true;
                    }
                }
            }

            if (title_state == 2) 
            {
                if (playMenu_selection < 0)
                    playMenu_selection = 0;

                if (playMenu_selection > 1)
                    playMenu_selection = 1;

                if (Input.keyDown || Input.LjoystickDown || Input.RjoystickDown)
                {
                    if ((lastTime + intervalBetween) < gameTime.TotalGameTime)
                    {
                        playMenu_selection++;
                        lastTime = gameTime.TotalGameTime;
                    }
                    else
                    {
                        //Do nothing
                        //Wait
                    }
                }

                if (Input.keyUp || Input.LjoystickUp || Input.RjoystickUp)
                {
                    if ((lastTime + intervalBetween) < gameTime.TotalGameTime)
                    {
                        playMenu_selection--;
                        lastTime = gameTime.TotalGameTime;
                    }
                    else
                    {
                        //Do nothing
                        //Wait
                    }
                }

                if (Input.keyLeft || Input.buttonB)
                {
                    playMenu_selection = 0;
                    title_state = 1;
                }

                if (Input.keyEnter || Input.buttonA || Input.keyRight)
                {
                    if (playMenu_selection == 0) { }

                    if (playMenu_selection == 1)
                    {
                        GameStates.current_state = GameStates.GameState.SURVIVAL;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            Renderer.FillRectangle(spriteBatch, new Vector2(310, 300), 150, 110, Color.Black);

            if (title_state == 1)
            {
                Renderer.FillRectangle(spriteBatch, new Vector2(330, (menu_selection * 25) + 310), 15, 15, Color.White);

                playItem.Draw(spriteBatch);
                optionsItem.Draw(spriteBatch);
                credits.Draw(spriteBatch);
                exit.Draw(spriteBatch);
            }

            if (title_state == 2) 
            {
                Renderer.FillRectangle(spriteBatch, new Vector2(330, (playMenu_selection * 25) + 310), 15, 15, Color.White);

                storyItem.Draw(spriteBatch);
                survivalItem.Draw(spriteBatch);
            }
        }
    }
}
