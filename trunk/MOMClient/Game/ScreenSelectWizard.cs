
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
    class ScreenSelectWizard : GameScreen
    {
        // Data
        Int32 ButtonPressed = 0;
        Boolean ButtonDown = false;        
        ArrayList Wizards;


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
            Wizards = new ArrayList();

            //Wizards.Add("Blank"); // 0 space
            Wizards.Add("Merlin");
            Wizards.Add("Sss'ra");
            Wizards.Add("Raven");
            Wizards.Add("Tauron");
            Wizards.Add("Sharee");
            Wizards.Add("Freya");
            Wizards.Add("Lo'Pan");
            Wizards.Add("Horus");
            Wizards.Add("Jafar");
            Wizards.Add("Ariel");
            Wizards.Add("Oberic");            
            Wizards.Add("Tlaloc");
            Wizards.Add("Rjak");
            Wizards.Add("Kali");
            Wizards.Add("Blank");
            Wizards.Add("Custom");
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
                // mmb - tyring a new thing here...
                CurrentMouseState = Mouse.GetState();
                CheckMouse(CurrentMouseState);

                // draw background first
                spriteBatch.Begin(SpriteBlendMode.None);
                spriteBatch.Draw(textureScreen, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                spriteBatch.End();
                                
                // Buttons:
                // Button Size = 68 x 30.
                spriteBatch.Begin(SpriteBlendMode.None);

                Int32 x = 0, y = 0, z = 0, button = 1;


                foreach (String Wizard in Wizards)
                {
                    // Draw each Button 251 x 41

                    // calculate x
                    if (button == 1)
                    {
                        // start here at the first button
                        x = 341;
                        y = 50;
                        z = 0;
                    }
                    else if (button % 2 == 0)
                    {
                        // even button - increment x
                        x += 151;
                    }
                    else 
                    {
                        // odd button - increment y
                        y += 44;
                        x -= 151;
                    }

                    // calculate z
                    if (button > 0 && ButtonDown)//button == ButtonPressed)
                    {
                        z = 15;
                        ButtonDown = false;
                        // go to the next screen
                        CurrentScreen = CurrentGameScreen.SelectWizardName;
                    }

                    if (Wizard != "Blank")
                    {
                        // draw the button
                        spriteBatch.Draw(textureButton, new Rectangle(x, y, 136, 30), new Rectangle(0, z, 68, 15), Color.White);
                    }
                    
                    // reset the button up or down var
                    z = 0;
                    button++;
                }
                spriteBatch.End();   
                
                /*
                // Draw Text:
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
                    // check the y position now
                    // +30/+46
                    if (Y > 50 && Y < 80)
                    {
                        ButtonPressed = 1;
                    }
                    else if (Y > 126 && Y < 156)
                    {
                        ButtonPressed = 3;
                    }
                    else if (Y > 191 && Y < 221)
                    {
                        ButtonPressed = 5;
                    }
                    else if (Y > 267 && Y < 297)
                    {
                        ButtonPressed = 7;
                    }
                    //else // mmb - this is where a cancel button would go...
                }
                else if (X > 491 && X < 627)
                {
                    // check the y position now
                    // +30/+46
                    // check the y position now
                    // +30/+46
                    if (Y > 50 && Y < 80)
                    {
                        ButtonPressed = 2;
                    }
                    else if (Y > 126 && Y < 156)
                    {
                        ButtonPressed = 4;
                    }
                    else if (Y > 191 && Y < 221)
                    {
                        ButtonPressed = 6;
                    }
                    else if (Y > 267 && Y < 297)
                    {
                        ButtonPressed = 8;
                    }
                    else if (Y > 343 && Y < 373)
                    {
                        // Custom
                        ButtonPressed = 10;
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
