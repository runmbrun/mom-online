
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
        ArrayList Buttons;        
        


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
                font = content.Load<SpriteFont>(@"fonts\ERBukinist");

                textureScreen = content.Load<Texture2D>(@"bg\bg_wizard");
                textureButton = content.Load<Texture2D>(@"buttons\wizard");

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
            Int32 x = 0, y = 0;
            Int32 l = 136, w = 30;
            Boolean Add = true;
            Buttons = new ArrayList();


            // this screen has 15 buttons
            for (Int32 i = 1; i <= 16; i++)
            {
                // create a new button
                ButtonInfo bi = new ButtonInfo();

                bi.Number = i;

                if (i == 1)
                {
                    x = 340;
                    y = 50;
                }
                else if (i % 2 == 0)
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
                bi.Location = new Rectangle(x, y, l, w);

                // reset add check
                Add = true;


                // add the button's text
                switch (i)
                {
                    case 1:
                        bi.Name = "Merlin";
                        break;
                    case 2:
                        bi.Name = "Sss'ra";
                        break;
                    case 3:
                        bi.Name = "Raven";
                        break;
                    case 4:
                        bi.Name = "Tauron";
                        break;
                    case 5:
                        bi.Name = "Sharee";
                        break;
                    case 6:
                        bi.Name = "Freya";
                        break;
                    case 7:
                        bi.Name = "Lo'Pan";
                        break;
                    case 8:
                        bi.Name = "Horus";
                        break;
                    case 9:
                        bi.Name = "Jafar";
                        break;
                    case 10:
                        bi.Name = "Ariel";
                        break;
                    case 11:
                        bi.Name = "Oberic";
                        break;
                    case 12:
                        bi.Name = "Tlaloc";
                        break;
                    case 13:
                        bi.Name = "Rjak";
                        break;
                    case 14:
                        bi.Name = "Kali";
                        break;
                    case 16:
                        bi.Name = "Custom";
                        break;
                    default:
                        Add = false;
                        break;
                }

                if (Add)
                {
                    Buttons.Add(bi);
                }
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

                if (FirstDisplay)
                {
                    ButtonDown = false;
                    FirstDisplay = false;
                }

                // check the mouse buttons
                CurrentMouseState = Mouse.GetState();
                CheckMouse(CurrentMouseState);
                OldMouseState = CurrentMouseState;

                // draw background first
                spriteBatch.Begin(SpriteBlendMode.None);
                spriteBatch.Draw(textureScreen, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                spriteBatch.End();
                                
                // Draw the Buttons:
                // Button Size = 68 x 30.
                spriteBatch.Begin(SpriteBlendMode.None);

                Int32 z = 0, button = 1;


                foreach (ButtonInfo Wizard in Buttons)
                {   
                    // calculate z
                    if (Wizard.Number > 0 && ButtonDown)
                    {
                        z = 15;
                                                
                        ButtonDown = false;
                        ChangeScreens = true;
                    }

                    // draw the button
                    spriteBatch.Draw(textureButton, Wizard.Location, new Rectangle(0, z, 68, 15), Color.White);
                    
                    // reset the button up or down var
                    z = 0;
                    button++;
                }
                spriteBatch.End();

                // Draw Text:
                spriteBatch.Begin();
                foreach (ButtonInfo Wizard in Buttons)
                {
                    DrawTextOnButton(font, Wizard.Name, Wizard.Location, Color.Black);
                }
                spriteBatch.End();

                if (ChangeScreens)
                {
                    // go to the next screen
                    CurrentScreen = CurrentGameScreen.SelectWizardName;
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
        /// Check to see where the mouse on the screen
        /// </summary>
        /// <param name="mouse"></param>
        public void CheckMouse(MouseState mouse)
        {
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
                // the mouse was clicked
                foreach (ButtonInfo button in Buttons)
                {
                    if (X > button.Location.Left && X < button.Location.Right &&
                        Y > button.Location.Top && Y < button.Location.Bottom)
                    {
                        ButtonPressed = button.Number;
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
