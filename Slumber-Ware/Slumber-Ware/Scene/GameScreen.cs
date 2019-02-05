using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;

namespace Slumber_Ware
{
    public class GameScreen // classe de base étant appelé par ScreenManager et étant override par le screen utilisé
    {
        protected ContentManager content; // ContentManager ne pouvant etre utilisé directement que par Gamescreen ou les classes héréditaire d'elle

        public virtual void LoadContent() // le load content appele 1 fois au debut 
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content"); // initialisation pour savoir ou aller chercher les images ou son a load
        }

        public virtual void UnloadContent() // l'unload content appele un fois à la fin
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime) // update appele 60fois par seconde si l'ordinateur est assez puissant
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch) // draw appele 60fois par seconde si l'ordinateur est assez puissant
        {

        }
    }
}
