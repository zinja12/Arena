using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FriendshipArena
{
    public class Input
    {
        public static bool keyW;
        public static bool keyA;
        public static bool keyS;
        public static bool keyD;
        public static bool keyUp;
        public static bool keyLeft;
        public static bool keyDown;
        public static bool keyRight;
        public static bool keyEsc;
        public static bool keyEnter;

        public static bool buttonA;
        public static bool buttonB;
        public static bool buttonX;
        public static bool buttonY;
        public static bool LjoystickLeft;
        public static bool LjoystickRight;
        public static bool LjoystickUp;
        public static bool LjoystickDown;
        public static bool RjoystickLeft;
        public static bool RjoystickRight;
        public static bool RjoystickUp;
        public static bool RjoystickDown;
        public static bool buttonStart;

        KeyboardState ks;
        GamePadState gps_1;

        public Input() 
        {
        }

        public void Update(GameTime gameTime) 
        {
            ks = Keyboard.GetState();
            gps_1 = GamePad.GetState(PlayerIndex.One);

            if (ks.IsKeyDown(Keys.W))
                keyW = true;
            else
                keyW = false;

            if (ks.IsKeyDown(Keys.A))
                keyA = true;
            else
                keyA = false;

            if (ks.IsKeyDown(Keys.S))
                keyS = true;
            else
                keyS = false;

            if (ks.IsKeyDown(Keys.D))
                keyD = true;
            else
                keyD = false;

            if (ks.IsKeyDown(Keys.Up))
                keyUp = true;
            else
                keyUp = false;

            if (ks.IsKeyDown(Keys.Left))
                keyLeft = true;
            else
                keyLeft = false;

            if (ks.IsKeyDown(Keys.Down))
                keyDown = true;
            else
                keyDown = false;

            if (ks.IsKeyDown(Keys.Right))
                keyRight = true;
            else
                keyRight = false;

            if (ks.IsKeyDown(Keys.Escape))
                keyEsc = true;
            else
                keyEsc = false;

            if (ks.IsKeyDown(Keys.Enter))
                keyEnter = true;
            else
                keyEnter = false;

            //Check if the gamepad is connected before polling input
            if (gps_1.IsConnected) 
            {
                //Buttons
                if (gps_1.Buttons.A == ButtonState.Pressed)
                    buttonA = true;
                else
                    buttonA = false;

                if (gps_1.Buttons.B == ButtonState.Pressed)
                    buttonB = true;
                else
                    buttonB = false;

                if (gps_1.Buttons.X == ButtonState.Pressed)
                    buttonX = true;
                else
                    buttonX = false;

                if (gps_1.Buttons.Y == ButtonState.Pressed)
                    buttonY = true;
                else
                    buttonY = false;

                if (gps_1.Buttons.Start == ButtonState.Pressed)
                    buttonStart = true;
                else
                    buttonStart = false;

                //Left Thumbstick
                if (gps_1.ThumbSticks.Left.X < 0.0f)
                    LjoystickLeft = true;
                else
                    LjoystickLeft = false;

                if (gps_1.ThumbSticks.Left.X > 0.0f)
                    LjoystickRight = true;
                else
                    LjoystickRight = false;

                if (gps_1.ThumbSticks.Left.Y < 0.0f)
                    LjoystickDown = true;
                else
                    LjoystickDown = false;

                if (gps_1.ThumbSticks.Left.Y > 0.0f)
                    LjoystickUp = true;
                else
                    LjoystickUp = false;

                //Right Thumbstick
                if (gps_1.ThumbSticks.Right.X < 0.0f)
                    RjoystickLeft = true;
                else
                    RjoystickLeft = false;

                if (gps_1.ThumbSticks.Right.X > 0.0f)
                    RjoystickRight = true;
                else
                    RjoystickRight = false;

                if (gps_1.ThumbSticks.Right.Y < 0.0f)
                    RjoystickDown = true;
                else
                    RjoystickDown = false;

                if (gps_1.ThumbSticks.Right.Y > 0.0f)
                    RjoystickUp = true;
                else
                    RjoystickUp = false;
            }
        }
    }
}
