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
        Boolean ButtonUp = false;
        Boolean Change = false; 

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
                font = content.Load<SpriteFont>(@"fonts\ERBukinist");

                textureScreen = content.Load<Texture2D>(@"bg\bg_options");
                textureButton = content.Load<Texture2D>(@"buttons\blank");

                CreateButtonData();

                ButtonDown = false;
                FirstDisplay = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Fill out all available options for the player
        /// </summary>
        private void CreateButtonData()
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

                                
                // Draw the Buttons
                Int32 x = 0, y = 0, z = 0, button = 1;
                
                spriteBatch.Begin(SpriteBlendMode.None);
                foreach (String Option in Options.Keys)
                {
                    // Draw each Button 251 x 41

                    // calculate x
                    if (button == 1)
                    {
                        // start here at the first button
                        x = 503;
                        y = 84;
                        z = 0;
                    }                    
                    else
                    {
                        // even button - increment x
                        y += 54;
                    }

                    // calculate z
                    if (ButtonPressed > 0 && ButtonPressed == button)
                    {
                        z = 15;
                    }

                    if (ButtonPressed > 0 && ButtonUp && Change)
                    {
                        Change = false;

                        switch (ButtonPressed)
                        {
                            case 1:
                                SelectedOptions["Difficulty"] += 1;
                                break;
                            case 2:
                                SelectedOptions["Opponents"] += 1;
                                break;
                            case 3:
                                SelectedOptions["Land Size"] += 1;
                                break;
                            case 4:
                                SelectedOptions["Magic"] += 1;
                                break;
                        }

                        CheckSelectedOptions();

                        ButtonPressed = 0;
                    }

                    // draw the button
                    spriteBatch.Draw(textureButton, new Rectangle(x, y, 130, 32), new Rectangle(0, z, 65, 16), Color.White);
                    //DrawTextOnButton(font, Options[Option][SelectedOptions[Option]], new Rectangle(x, y, 130, 32), Color.Black);
                    
                    // reset the button up or down var
                    z = 0;
                    button++;
                }
                // Ok Button
                spriteBatch.Draw(textureButton, new Rectangle(342, 360, 130, 32), new Rectangle(0, 0, 65, 16), Color.White);
                //DrawTextOnButton(font, "Ok", new Rectangle(342, 360, 130, 32), Color.Black);                
                // Cancel Button
                spriteBatch.Draw(textureButton, new Rectangle(503, 360, 130, 32), new Rectangle(0, 0, 65, 16), Color.White);
                //DrawTextOnButton(font, "Cancel", new Rectangle(503, 360, 130, 32), Color.Black);
                spriteBatch.End();   
                               

                // Options Text:
                x = 0;
                y = 0;
                button = 1;
                spriteBatch.Begin();
                // mmb - change these to get a better font
                foreach (String Option in Options.Keys)
                {
                    // Draw each Button 251 x 41

                    // calculate x
                    if (button == 1)
                    {
                        // start here at the first button
                        x = 503;
                        y = 84;
                        z = 0;
                    }                    
                    else
                    {
                        // even button - increment x
                        y += 54;
                    }

                    DrawTextOnButton(font, Options[Option][SelectedOptions[Option]], new Rectangle(x, y, 130, 32), Color.Black);
                    button++;
                }
                DrawTextOnButton(font, "Ok", new Rectangle(342, 360, 130, 32), Color.Black);
                DrawTextOnButton(font, "Cancel", new Rectangle(503, 360, 130, 32), Color.Black);
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


            // mmb - temp fix for now...
            Int32 Button = GetButton(MouseX, MouseY);


            if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                ButtonUp = true;

                // a button was released                
                if (Button != 0 && Button == ButtonPressed && ButtonPressed != 0)
                {
                    Change = true;
                }
            }
            else if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && Button != 0)
            {
                // a button was pressed
                ButtonPressed = Button;

                // check x position
                switch (ButtonPressed)
                {
                    case 5:
                        // OK
                        CurrentScreen = CurrentGameScreen.SelectWizard;
                        break;
                    case 6:
                        // Cancel
                        CurrentScreen = CurrentGameScreen.None;
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public Int32 GetButton(Int32 X, Int32 Y)
        {
            Int32 Button = 0;

            // check x position
            if (X > 344 && X < 468)
            {
                if (Y > 360 && Y < 390)
                {
                    // OK
                    Button = 5;
                }
            }
            else if (X > 505 && X < 629)
            {
                // check the y position now
                if (Y > 84 && Y < 114)
                {
                    Button = 1;
                }
                else if (Y > 137 && Y < 167)
                {
                    Button = 2;
                }
                else if (Y > 191 && Y < 221)
                {
                    Button = 3;
                }
                else if (Y > 246 && Y < 276)
                {
                    Button = 4;
                }
                else if (Y > 360 && Y < 390)
                {
                    // Cancel
                    Button = 6;
                }
            }

            return Button;
        }
    }
}
