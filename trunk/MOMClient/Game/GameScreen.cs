
#region File Description
//-----------------------------------------------------------------------------
// GameScreen.cs
//
// This Class is a base class for all other screens.
// Everything should go in here that deals with the screen:
// Background, text, fonts, buttons, clicking, etc
// 
//-----------------------------------------------------------------------------
#endregion


#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion



namespace MOM
{
    class GameScreen : GameControl
    {
        /// <summary>
        /// Screen Constructor
        /// </summary>
        public GameScreen()
        {            
        }

        /// <summary>
        /// Screen Constructor
        /// </summary>
        public GameScreen(ContentManager BaseContent, SpriteBatch BaseSpriteBatch)
        {
            // Pass in the BaseSpriteBatch and the BaseContent from the original Control Class
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
        /// Draw class
        /// </summary>
        public override void Draw()
        {
        }

        /// <summary>
        /// Check to see where the mouse is clicked
        /// </summary>
        /// <param name="Mouse"></param>
        /// <returns></returns>
        public override void UpdateGame(MouseEventArgs Mouse)
        {
        }
    }
}
