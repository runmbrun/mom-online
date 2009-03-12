
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
    class ScreenSelectWizardName : GameScreen
    {
        // Data
        Int32 ButtonPressed = 0;
        Boolean ButtonDown = false;
        ArrayList Wizards;


        /// <summary>
        /// Screen Constructor
        /// </summary>
        public ScreenSelectWizardName(ContentManager BaseContent, SpriteBatch BaseSpriteBatch)
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
                font = content.Load<SpriteFont>(@"fonts\EnglishGothic");

                textureScreen = content.Load<Texture2D>(@"bg\bg_name");
                textureButton = content.Load<Texture2D>(@"buttons\wizard");

                // mmb - do we want this in here?
                // Hook the idle event to constantly redraw our animation.
                //Application.Idle += delegate { Invalidate(); };
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

        public override void Draw()
        {
            try
            {
                // draw background first
                spriteBatch.Begin(SpriteBlendMode.None);
                spriteBatch.Draw(textureScreen, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                spriteBatch.End();
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
            //mmb - why can't I make this work?
            // can't get the relative x in the control... only the entire screen x
            //Int32 X = mouse.X - Left;
            //Int32 Y = mouse.Y - Top;


            Int32 X = MouseX;
            Int32 Y = MouseY;

            if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                // a button was released
                ButtonDown = false;
                ButtonPressed = 0;
            }
            else if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && ButtonPressed == 0)
            {
                // check x position                
                if (X > 341 && X < 477)
                {
                    
                }

                if (ButtonPressed > 0)
                {
                    ButtonDown = true;
                }
            }
        }
    }
}
