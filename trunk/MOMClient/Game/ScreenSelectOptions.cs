using System;
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
    class ScreenSelectOptions : GameScreen
    {
        // Data
        Int32 ButtonPressed = 0;
        Boolean ButtonDown = false;        

        // Need to be able to pass this info back to the GameControl object
        public Dictionary<String, String[]> Options;
        public Dictionary<String, Int32> SelectedOptions;



        /// <summary>
        /// Screen Constructor
        /// </summary>
        public ScreenSelectOptions(ContentManager BaseContent, SpriteBatch BaseSpriteBatch)
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

                textureScreen = content.Load<Texture2D>(@"bg\bg_options");
                textureButton = content.Load<Texture2D>(@"buttons\wizard");

                // mmb - do we want this in here?
                // Hook the idle event to constantly redraw our animation.
                //Application.Idle += delegate { Invalidate(); };
                                
                FillOutOptions();

                // mmb - this doesn't seem to work... maybe save value as a member var
                CurrentMouseState = new MouseState();
                Mouse.WindowHandle = this.Handle;
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
            Options.Add("Magic", new String[] { "Weak", "Normal", "Strong" });

            SelectedOptions = new Dictionary<string, int>();
            SelectedOptions.Add("Difficulty", 1);
            SelectedOptions.Add("Opponents", 0);
            SelectedOptions.Add("Land Size", 1);
            SelectedOptions.Add("Magic", 1);
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
            // mmb - tyring a new thing here...
            CurrentMouseState = Mouse.GetState();
            CheckMouse(CurrentMouseState);

            try
            {
                // draw background first
                spriteBatch.Begin(SpriteBlendMode.None);
                spriteBatch.Draw(textureScreen, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                spriteBatch.End();

                // now draw the buttons
                Int32 B1x = 0, B2x = 0, B3x = 0, B4x = 0, B5x = 0, B6x = 0;

                if (ButtonPressed > 0)
                {
                    switch (ButtonPressed)
                    {
                        case 1: 
                            B1x = 15;
                            if (ButtonDown)
                            {
                                SelectedOptions["Difficulty"] += 1;
                                ButtonDown = false;
                            }
                            break;
                        case 2:                            
                            B2x = 15;
                            if (ButtonDown)
                            {
                                SelectedOptions["Opponents"] += 1;
                                ButtonDown = false;
                            }
                            break;
                        case 3:
                            B3x = 15;
                            if (ButtonDown)
                            {
                                SelectedOptions["Land Size"] += 1;
                                ButtonDown = false;
                            }
                            break;
                        case 4:
                            B4x = 15;
                            if (ButtonDown)
                            {
                                SelectedOptions["Magic"] += 1;
                                ButtonDown = false;
                            }
                            break;
                        case 5:
                            B5x = 15;
                            break;
                        case 6:
                            B6x = 15;
                            break;
                    }
                }

                CheckSelectedOptions();
                
                // Options Buttons:
                // Button Size = 68 x 30.
                spriteBatch.Begin(SpriteBlendMode.None);
                // First Button - Difficulty.  251 x 41
                spriteBatch.Draw(textureButton, new Rectangle(505, 84, 124, 30), new Rectangle(0, B1x, 68, 15), Color.White);                
                // Second Button - Opponents.  
                spriteBatch.Draw(textureButton, new Rectangle(505, 137, 124, 30), new Rectangle(0, B2x, 68, 15), Color.White);                
                // Third Button - Land Size
                spriteBatch.Draw(textureButton, new Rectangle(505, 191, 124, 30), new Rectangle(0, B3x, 68, 15), Color.White);                
                // Fourth Button - Magic
                spriteBatch.Draw(textureButton, new Rectangle(505, 246, 124, 30), new Rectangle(0, B4x, 68, 15), Color.White);
                // Fifth Button - Ok
                spriteBatch.Draw(textureButton, new Rectangle(344, 360, 124, 30), new Rectangle(0, B5x, 68, 15), Color.White);                
                // Sixth Button - Cancel
                spriteBatch.Draw(textureButton, new Rectangle(506, 360, 124, 30), new Rectangle(0, B6x, 68, 15), Color.White);
                spriteBatch.End();

                // Options Text:
                spriteBatch.Begin();
                spriteBatch.DrawString(font, Options["Difficulty"][SelectedOptions["Difficulty"]], new Vector2(525, 92), Color.White);
                spriteBatch.DrawString(font, Options["Opponents"][SelectedOptions["Opponents"]], new Vector2(525, 147), Color.White);
                spriteBatch.DrawString(font, Options["Land Size"][SelectedOptions["Land Size"]], new Vector2(525, 201), Color.White);
                spriteBatch.DrawString(font, Options["Magic"][SelectedOptions["Magic"]], new Vector2(525, 254), Color.White);
                spriteBatch.DrawString(font, "Ok", new Vector2(346, 370), Color.White);
                spriteBatch.DrawString(font, "Cancel", new Vector2(516, 370), Color.White);
                spriteBatch.End();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckSelectedOptions()
        {
            if (SelectedOptions["Difficulty"] > 4)
            {
                SelectedOptions["Difficulty"] = 0;
            }

            if (SelectedOptions["Opponents"] > 3)
            {
                SelectedOptions["Opponents"] = 0;
            }

            if (SelectedOptions["Land Size"] > 2)
            {
                SelectedOptions["Land Size"] = 0;
            }

            if (SelectedOptions["Magic"] > 2)
            {
                SelectedOptions["Magic"] = 0;
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

        ///
        public void CheckMouse(MouseState mouse)
        {
            //Form test = this.FindForm();
            //Mouse.WindowHandle = this.Handle;


            //if (mouse.X > test.Left && mouse.X < test.Right &&
            //    mouse.Y > test.Top && mouse.Y < test.Bottom)
            
            //if (test.Left)
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
                    // a button was pressed

                    // check x position
                    if (X > 344 && X < 468)
                    {
                        if (Y > 360 && Y < 390)
                        {
                            // OK
                            ButtonPressed = 5;
                            CurrentScreen = CurrentGameScreen.SelectWizard;
                        }
                    }
                    else if (X > 505 && X < 629)
                    {
                        // check the y position now
                        if (Y > 84 && Y < 114)
                        {
                            ButtonPressed = 1;
                        }
                        else if (Y > 137 && Y < 167)
                        {
                            ButtonPressed = 2;
                        }
                        else if (Y > 191 && Y < 221)
                        {
                            ButtonPressed = 3;
                        }
                        else if (Y > 246 && Y < 276)
                        {
                            ButtonPressed = 4;
                        }
                        else if (Y > 360 && Y < 390)
                        {
                            // Cancel
                            ButtonPressed = 6;
                            CurrentScreen = CurrentGameScreen.None;
                        }
                    }

                    if (ButtonPressed > 0)
                    {
                        ButtonDown = true;
                    }
                }
            }
        }
    }
}
