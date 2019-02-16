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
    public class SceneTest : GameScreen
    {
        //instance de classe

        public override void LoadContent()
        {
            base.LoadContent();
            //on load toutes les images et les classes nécessaires
        }

        public override void UnloadContent() // on unload tous ce que l'on a load
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
           if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                ScreenManager.Instance.ChangeScreens("Menu");
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ScreenManager.Instance.GraphicsDevice.Clear(Color.Blue);
            base.Draw(spriteBatch);
        }
    }
}
