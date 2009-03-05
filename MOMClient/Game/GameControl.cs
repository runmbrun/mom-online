
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
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D textureMain, textureMainAnimation;
        GameOptionsScreen screenOptions;

        // Screen Info
        public Int32 ScreenX = 640;
        public Int32 ScreenY = 400;

        // Game State Info
        public enum GameScreen
        {
            Options,
            ChooseWizard,
            Game,
            None
        }

        // Game State
        private static GameScreen gameScreen = GameScreen.None;

        // Game Data
        // mmb - todo
        // MOMGame game = new MOMGame();
        

        // Animations
        Stopwatch GameTimer;
        Int32 GameTick = 0;


        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                content = new ContentManager(Services, "Content");

                spriteBatch = new SpriteBatch(GraphicsDevice);

                font = content.Load<SpriteFont>(@"fonts\Arial");

                textureMain = content.Load<Texture2D>(@"bg\bg_main");
                textureMainAnimation = content.Load<Texture2D>(@"animations\anim");

                screenOptions = new GameOptionsScreen(content, spriteBatch);

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


                if (gameScreen == GameScreen.Options)
                {
                    screenOptions.Draw();
                }
                else if (gameScreen == GameScreen.ChooseWizard)
                {
                    // mmb - todo
                    //screenChooseWizard.Draw();
                }
                else
                {
                    // there is no game state, so display the title page!
                    spriteBatch.Begin(SpriteBlendMode.None);

                    // main background
                    spriteBatch.Draw(textureMain, new Rectangle(0, 0, ScreenX, ScreenY), Color.White);
                    
                    // animation.  320 x 820.  20 frames.  Each frame is 320 x 41.  Everything * 2!
                    // mmb- this needs to be animated faster!
                    GameTick = Convert.ToInt32(time % 20.0f);                    
                    spriteBatch.Draw(textureMainAnimation, new Rectangle(0, 0, 640, 82), new Rectangle(0, (GameTick * 41), 320, 41), Color.White);
                    spriteBatch.End();

                    // mmb - debugging message
                    const string message = "DEBUGGING!\n";
                    spriteBatch.Begin();
                    spriteBatch.DrawString(font, message, new Vector2(23, 23), Color.White);
                    spriteBatch.End();
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
        public void UpdateGame(MouseEventArgs Mouse)
        {
            // update the game data to update the screens
            if (gameScreen == GameScreen.Options)
            {
                gameScreen = screenOptions.Update(Mouse);
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
            gameScreen = GameScreen.Options;
        }
    }
}
