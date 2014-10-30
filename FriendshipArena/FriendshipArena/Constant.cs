using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FriendshipArena
{
    public class Constant
    {
        public static Texture2D players_SpriteSheet;
        public static Texture2D pixel_SPR;
        public static Texture2D enemy_SPR;
        public static Texture2D texture_SpriteSheet;
        public static Texture2D cursor_SPR;
        public static SpriteFont lilyUPCFont;
        public static Texture2D enemy_SpriteSheet;

        public static bool quit_game = false;

        public static int player_Size = 10;
        public static int enemy_Size = 32;
        public static int block_Size = 32;
        public static int cursor_Size = 15;

        public static int[] air = { 0, 0 };
        public static int[] stone = { 1, 0 };
        public static int[] darkstone_wall = { 0, 1 };
        public static int[] light_stone = { 1, 1 };
        public static int[] lightStone_wall = { 2, 1 };
        public static int[] dark_stone = { 0, 2 };
        public static int[] white_stone = { 1, 2 };
    }
}
