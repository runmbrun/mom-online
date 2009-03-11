using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;



namespace MOM
{
    class ScreenSelectWizard : GameScreen
    {
        // Data
        //Int32 ButtonPressed = 0;

        // Need to be able to pass this info back to the GameControl object
        public Dictionary<String, String[]> Options;



        /// <summary>
        /// Screen Constructor
        /// </summary>
        public ScreenSelectWizard(ContentManager BaseContent, SpriteBatch BaseSpriteBatch)
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

                textureScreen = content.Load<Texture2D>(@"bg\bg_wizard");
                textureButton = content.Load<Texture2D>(@"buttons\wizard");

                // mmb - do we want this in here?
                // Hook the idle event to constantly redraw our animation.
                //Application.Idle += delegate { Invalidate(); };

                FillOutOptions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Fill out all available options for the player
        /// </summary>
        private void FillOutOptions()
        {
            Options = new Dictionary<String, String[]>();

            Options.Add("Difficulty", new String[] { "Intro", "Easy", "Normal", "Hard", "Impossible" });
            Options.Add("Opponents", new String[] { "One", "Two", "Three", "Four" });
            Options.Add("Land Size", new String[] { "Small", "Medium", "Large" });
            Options.Add("Magic", new String[] { "Weak", "Medium", "Strong" });
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

                /*
                // now draw the buttons
                Int32 B1x = 0, B2x = 0, B3x = 0, B4x = 0, B5x = 0, B6x = 0;

                if (ButtonPressed > 0)
                {
                    switch (ButtonPressed)
                    {
                        case 1:
                            B1x = 15;
                            break;
                        case 2:
                            B2x = 15;
                            break;
                        case 3:
                            B3x = 15;
                            break;
                        case 4:
                            B4x = 15;
                            break;
                        case 5:
                            B5x = 15;
                            break;
                        case 6:
                            B6x = 15;
                            break;
                    }
                }

                // Options Buttons:
                // Button Size = 68 x 30.
                spriteBatch.Begin(SpriteBlendMode.None);
                // First Button - Difficulty.  251 x 41
                spriteBatch.Draw(textureOptionsButton, new Rectangle(505, 84, 124, 30), new Rectangle(0, B1x, 68, 15), Color.White);
                // Second Button - Opponents.  
                spriteBatch.Draw(textureOptionsButton, new Rectangle(505, 137, 124, 30), new Rectangle(0, B2x, 68, 15), Color.White);
                // Third Button - Land Size
                spriteBatch.Draw(textureOptionsButton, new Rectangle(505, 191, 124, 30), new Rectangle(0, B3x, 68, 15), Color.White);
                // Fourth Button - Magic
                spriteBatch.Draw(textureOptionsButton, new Rectangle(505, 246, 124, 30), new Rectangle(0, B4x, 68, 15), Color.White);
                // Fifth Button - Ok
                spriteBatch.Draw(textureOptionsButton, new Rectangle(344, 360, 124, 30), new Rectangle(0, B5x, 68, 15), Color.White);
                // Sixth Button - Cancel
                spriteBatch.Draw(textureOptionsButton, new Rectangle(506, 360, 124, 30), new Rectangle(0, B6x, 68, 15), Color.White);
                spriteBatch.End();

                // Options Text:
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Difficulty", new Vector2(525, 92), Color.White);
                spriteBatch.DrawString(font, "Opponents", new Vector2(525, 147), Color.White);
                spriteBatch.DrawString(font, "Land Size", new Vector2(525, 201), Color.White);
                spriteBatch.DrawString(font, "Magic", new Vector2(525, 254), Color.White);
                spriteBatch.DrawString(font, "Ok", new Vector2(346, 370), Color.White);
                spriteBatch.DrawString(font, "Cancel", new Vector2(516, 370), Color.White);
                spriteBatch.End();
                 * */
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
        public override void UpdateGame(MouseEventArgs Mouse)
        {
            /*
            // check if a button was pressed
            if (Mouse.Button == MouseButtons.Left)
            {
                // check x position
                if (Mouse.X > 344 && Mouse.X < 468)
                {
                    if (Mouse.Y > 360 && Mouse.Y < 390)
                    {
                        // OK
                        ButtonPressed = 5;
                        CurrentScreen = CurrentGameScreen.SelectWizard;
                    }
                }
                else if (Mouse.X > 505 && Mouse.X < 629)
                {
                    // check the y position now
                    if (Mouse.Y > 84 && Mouse.Y < 114)
                    {
                        ButtonPressed = 1;
                    }
                    else if (Mouse.Y > 137 && Mouse.Y < 167)
                    {
                        ButtonPressed = 2;
                    }
                    else if (Mouse.Y > 191 && Mouse.Y < 221)
                    {
                        ButtonPressed = 3;
                    }
                    else if (Mouse.Y > 246 && Mouse.Y < 276)
                    {
                        ButtonPressed = 4;
                    }
                    else if (Mouse.Y > 360 && Mouse.Y < 390)
                    {
                        // Cancel
                        ButtonPressed = 6;
                        CurrentScreen = CurrentGameScreen.None;
                    }
                    else
                    {
                        ButtonPressed = 0;
                    }
                }
                else
                {
                    ButtonPressed = 0;
                }
            }
            * */

            // now trigger a draw call to update the screen
            //Draw();             
        }
    }
}
