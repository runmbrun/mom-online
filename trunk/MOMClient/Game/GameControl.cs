
#region File Description
//-----------------------------------------------------------------------------
// GameControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion


#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows.Forms;
using System.Diagnostics;
#endregion



namespace MOM
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to use ContentManager
    /// inside a WinForms application. It loads a SpriteFont object through the
    /// ContentManager, then uses a SpriteBatch to draw text. The control is not
    /// animated, so it only redraws itself in response to WinForms paint messages.
    /// </summary>
    class GameControl : GraphicsDeviceControl
    {
        // Graphics
        public ContentManager content;
        public SpriteBatch spriteBatch;
        public SpriteFont font;
        public Texture2D textureScreen, textureAnimation, textureCursor, textureButton;
        ScreenSelectOptions screenSelectOptions;
        ScreenSelectWizard screenSelectWizard;
        

        // Screen Info
        public Int32 ScreenX = 640;
        public Int32 ScreenY = 400;
        
        // Game State Info
        public enum CurrentGameScreen
        {
            SelectOptions,
            SelectWizard,
            SelectCustomPicture,
            SelectWizardName,
            SelectCustomBooks,
            SelectCustomSpells,
            SelectRace,
            SelectBanner,      
            Buildingworlds,
            Game,
            None
        }

        // Keep track of the current Screen for the game
        public static CurrentGameScreen CurrentScreen = CurrentGameScreen.None;

        // Game Data
        // mmb - todo
         public MOMGame game = new MOMGame();
         public MouseState CurrentMouseState;

        // Animations
        Stopwatch GameTimer;
        Int32 GameTick = 0;
        float LastTime = 0;
        public Int32 MouseX = 0;
        public Int32 MouseY = 0;


        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                // We aren't at a screen yet...
                CurrentScreen = CurrentGameScreen.None;
                
                // Init Graphics stuff
                content = new ContentManager(Services, "Content");
                spriteBatch = new SpriteBatch(GraphicsDevice);

                // load the font data files
                font = content.Load<SpriteFont>(@"fonts\Arial");

                // load the screen data files
                textureScreen = content.Load<Texture2D>(@"bg\bg_main");
                textureAnimation = content.Load<Texture2D>(@"animations\anim");
                textureCursor = content.Load<Texture2D>(@"cursors\hand");

                // load the screen classes
                // mmb - now or when needed?
                screenSelectOptions = new ScreenSelectOptions(content, spriteBatch);
                screenSelectWizard = new ScreenSelectWizard(content, spriteBatch);

                // Start the animation timer.
                GameTimer = Stopwatch.StartNew();

                // Hook the idle event to constantly redraw our animation.
                Application.Idle += delegate { Invalidate(); };
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
        /// Draws the control, using SpriteBatch and SpriteFont.
        /// </summary>
        public override void Draw()
        {
            // Check how much time has passed for the animations
            float time = (float)GameTimer.Elapsed.TotalSeconds;
            

            try
            {
                // clear the screen
                GraphicsDevice.Clear(Color.Black);

                // show the mouse cursor
                // mmb - TODO - still need to get the mouse position
                //this.spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
                //this.spriteBatch.Draw(textureCursor, new Vector2(MouseX, MouseY), Color.White);
                //this.spriteBatch.End();

                if (CurrentScreen == CurrentGameScreen.SelectOptions)
                {
                    screenSelectOptions.Draw();
                }
                else if (CurrentScreen == CurrentGameScreen.SelectWizard)
                {
                    screenSelectWizard.Draw();
                }
                else
                {
                    // there is no game state, so display the title page!
                    spriteBatch.Begin(SpriteBlendMode.None);

                    // main background
                    spriteBatch.Draw(textureScreen, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                    
                    // animation.  320 x 820.  20 frames.  Each frame is 320 x 41.  Everything * 2!                    
                    if (time - LastTime > .1f)
                    {
                        GameTick++;
                        if (GameTick >= 20)
                        {
                            GameTick = 0;
                        }

                        LastTime = time;
                    }
                    // mmb - old way... this needs to be animated faster!
                    //spriteBatch.Draw(textureAnimation, new Rectangle(0, 0, 640, 82), new Rectangle(0, ((Convert.ToInt32(time % 20.0f)) * 41), 320, 41), Color.White);
                    // mmb - new way!
                    spriteBatch.Draw(textureAnimation, new Rectangle(0, 0, 640, 82), new Rectangle(0, (GameTick * 41), 320, 41), Color.White);                                        
                    
                    spriteBatch.End();


                    // mmb - debugging message
                    const string message = "DEBUGGING!\n";
                    spriteBatch.Begin();
                    spriteBatch.DrawString(font, message, new Vector2(23, 23), Color.White);
                    spriteBatch.End();

                    // show the mouse cursor
                    // mmb - TODO - still need to get the mouse position
                    this.spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
                    this.spriteBatch.Draw(textureCursor, new Vector2(MouseX, MouseY), Color.White);
                    this.spriteBatch.End();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mouse"></param>
        public override void UpdateGame(MouseEventArgs MouseArgs)
        {
            MouseX = MouseArgs.X;
            MouseY = MouseArgs.Y;

 
            // update the game data to update the screens
            if (CurrentScreen == CurrentGameScreen.SelectOptions)
            {
                screenSelectOptions.UpdateGame(MouseArgs);
            }
            if (CurrentScreen == CurrentGameScreen.SelectOptions)
            {
                screenSelectWizard.UpdateGame(MouseArgs);
            }
            else
            {
                // there is no game state, so we are at the title page!
            }
        }

        /// <summary>
        /// Set the GameState to be a new Game with only 1 person playing
        /// </summary>
        internal void StartSolitareGame()
        {
            CurrentScreen = CurrentGameScreen.SelectOptions;
        }
    }
}
