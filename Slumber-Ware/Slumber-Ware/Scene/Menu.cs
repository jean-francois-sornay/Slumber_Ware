using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Slumber_Ware
{
    public class Menu : GameScreen
    {
        //instance de classe
        Button boutonTest;

        public override void LoadContent()
        {
            base.LoadContent();
            //on load toutes les images et les classes nécessaires

            boutonTest = new Button(content, "BackToMenu");
            boutonTest.posSize = (new Rectangle((int)ScreenManager.Instance.dimensions.X / 2 - boutonTest.image.Width / 2, 
                (int)(ScreenManager.Instance.dimensions.Y *2/9), boutonTest.image.Width, (int)(ScreenManager.Instance.dimensions.Y / 15)));
        }

        public override void UnloadContent() // on unload tous ce que l'on a load
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            ScreenManager.Instance.mouseState = Mouse.GetState(); // On obtient la position et l'état des boutons de la souris

            if (Keyboard.GetState().IsKeyDown(Keys.Z) || (boutonTest.update(ScreenManager.Instance.mouseState.Position.ToVector2()) && ScreenManager.Instance.mouseState.LeftButton == ButtonState.Pressed))
            {
                ScreenManager.Instance.ChangeScreens("SceneTest");
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Red);
            boutonTest.draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}