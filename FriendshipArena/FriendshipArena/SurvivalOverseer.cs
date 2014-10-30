using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class SurvivalOverseer
    {
        public static int enemiesDefeated;

        public Players players;
        public List<Door> doors;
        public Block[,] blocks;
        public List<Letter> letters;

        private int worldWidth;
        private int worldHeight;
        private bool canSpawn;
        private bool toggle1;

        public SurvivalOverseer(int worldWidth, int worldHeight) 
        {
            players = new Players(new Vector2(300, 300), new Vector2(350, 300));

            doors = new List<Door>();
            letters = new List<Letter>();

            generate_level(worldWidth, worldHeight);
            enemiesDefeated = 0;
            canSpawn = false;
            toggle1 = false;
        }

        public void generate_level(int worldWidth, int worldHeight) 
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            blocks = new Block[worldWidth, worldHeight];
            for (int x = 0; x < blocks.GetLength(0); x++) 
            {
                for (int y = 0; y < blocks.GetLength(1); y++)
                {
                    blocks[x, y] = new Block(new Vector2(x * Constant.block_Size, y * Constant.block_Size), Constant.white_stone);
                }
            }
        }

        public void Update(GameTime gameTime) 
        {
            players.Update(gameTime);

            if (!Players.alive) 
            {
                GameStates.current_state = GameStates.GameState.SURVIVAL_END;
            }

            //Spawn Doors if there are not enough
            if (doors.Count < 2)
            {
                doors.Add(new Door());
            }

            //Update Doors
            for (int i = 0; i < doors.Count; i++) 
            {
                doors[i].Update(gameTime);

                if (!doors[i].isVisible) 
                {
                    doors.RemoveAt(i);
                }
            }

            //Spawn Letter If Enough Enemies are Defeated
            if (enemiesDefeated != 0)
            {
                if ((enemiesDefeated % 10) == 0)
                {
                    canSpawn = true;
                }

                if ((enemiesDefeated % 10) != 0)
                {
                    canSpawn = false;
                    toggle1 = true;
                }

                if (toggle1)
                {
                    if (canSpawn)
                    {
                        letters.Add(new Letter(Maths.RandomPosition()));
                        toggle1 = false;
                    }
                }
            }

            //Update Letters
            for (int i = 0; i < letters.Count; i++) 
            {
                letters[i].Update(gameTime);
            }

            if (Input.buttonStart)
                GameStates.pause_game = true;

            Console.WriteLine("Enemies Defeated: " + enemiesDefeated);
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            {
                for (int y = 0; y < blocks.GetLength(1); y++)
                {
                    blocks[x, y].Draw(spriteBatch);
                }
            }

            players.Draw(spriteBatch);

            for (int i = 0; i < doors.Count; i++)
            {
                doors[i].Draw(spriteBatch);
            }

            for (int i = 0; i < letters.Count; i++) 
            {
                letters[i].Draw(spriteBatch);
            }
        }
    }
}
