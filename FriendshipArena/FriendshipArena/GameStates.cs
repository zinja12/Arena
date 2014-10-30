using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class GameStates
    {
        public enum GameState 
        {
            TITLE,
            OVERWORLD,
            SURVIVAL,
            STORY,
            SURVIVAL_END,
            STORY_END
        }
        public static GameState current_state;
        public static bool pause_game;

        Input input;

        SurvivalOverseer survival_overseer;
        TitleOverseer title_overseer;

        PauseOverseer pause_overseer;

        public GameStates() 
        {
            current_state = GameState.TITLE;
            pause_game = false;

            input = new Input();

            title_overseer = new TitleOverseer();
            survival_overseer = new SurvivalOverseer(25, 15);
            pause_overseer = new PauseOverseer();
        }

        public void Update(GameTime gameTime) 
        {
            input.Update(gameTime);

            if (current_state == GameState.TITLE) 
            {
                title_overseer.Update(gameTime);
            }

            if (current_state == GameState.OVERWORLD) { }

            if (current_state == GameState.SURVIVAL) 
            {
                if (!pause_game)
                {
                    survival_overseer.Update(gameTime);
                }

                if (pause_game) 
                {
                    pause_overseer.Update(gameTime);
                }
            }

            if (current_state == GameState.SURVIVAL_END) { }

            if (current_state == GameState.STORY) { }

            if (current_state == GameState.STORY_END) { }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            if (current_state == GameState.TITLE) 
            {
                title_overseer.Draw(spriteBatch);
            }

            if (current_state == GameState.OVERWORLD) { }

            if (current_state == GameState.SURVIVAL)
            {
                if (!pause_game)
                {
                    survival_overseer.Draw(spriteBatch);
                }

                if (pause_game) 
                {
                    pause_overseer.Draw(spriteBatch);
                }
            }

            if (current_state == GameState.SURVIVAL_END) { }

            if (current_state == GameState.STORY) { }

            if (current_state == GameState.STORY_END) { }
        }
    }
}
