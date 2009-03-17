
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace MOM
{
    class ScreenSelectRace : GameScreen
    {
        // Data


        /// <summary>
        /// Screen Constructor
        /// </summary>
        public ScreenSelectRace(ContentManager BaseContent, SpriteBatch BaseSpriteBatch)
        {
            spriteBatch = BaseSpriteBatch;
            content = BaseContent;
            Initialize();
        }

        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                // load the font data files
                font = content.Load<SpriteFont>(@"fonts\Arial");

                textureScreen = content.Load<Texture2D>(@"bg\bg_race");

                ButtonDown = false;
                FirstDisplay = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Disposes the control, unloading the ContentManager.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                content.Unload();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Draw this screen
        /// </summary>
        public override void Draw()
        {
            try
            {
                Boolean ChangeScreens = false;


                // check the mouse buttons
                CurrentMouseState = Mouse.GetState();
                CheckMouse(CurrentMouseState);
                OldMouseState = CurrentMouseState;

                // old mouse state isn't valid yet
                if (FirstDisplay)
                {
                    FirstDisplay = false;
                }

                // draw background first
                spriteBatch.Begin(SpriteBlendMode.None);
                spriteBatch.Draw(textureScreen, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                spriteBatch.End();

                // mmb - temp message
                const string message = "I'm sorry\nYou can't choose your own player race at this time.\nPlease click mouse to continue...\n";
                spriteBatch.Begin();
                spriteBatch.DrawString(font, message, new Vector2(23, 23), Color.White);
                spriteBatch.End();

                if (ButtonDown)
                {
                    ChangeScreens = true;
                }

                if (ChangeScreens)
                {
                    // move to next screen
                    CurrentScreen = CurrentGameScreen.SelectBanner;
                    FirstDisplay = true;
                    ButtonDown = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Check to see where the mouse is clicked
        /// </summary>
        /// <param name="Mouse"></param>
        /// <returns></returns>
        public override void UpdateGame(MouseEventArgs MouseArgs)
        {
            MouseX = MouseArgs.X;
            MouseY = MouseArgs.Y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouse"></param>
        public void CheckMouse(MouseState mouse)
        {
            if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                ButtonDown = false;
            }
            else if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && !FirstDisplay &&
                OldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                // left mouse button was just clicked
                ButtonDown = true;
            }
        }
    }
}
