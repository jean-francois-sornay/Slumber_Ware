using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slumber_Ware
{
    public class ScreenManager
    {
        private static ScreenManager instance;

        // content servant pour le content de la classe gamescreen et de ses classes filles
        public ContentManager Content;

        // variable de gamescreen: currentscreen permet de faire les actions du screen actuelle / newscreen permet de changer de screen
        GameScreen currentScreen, newScreen;

        // vecteur 2 dimension permettant de définir la taille de la fenêtre
        public Vector2 dimensions;

       // variable permettant d'avoir l'état de la souris
        public MouseState mouseState;

        // variable permettant de savoir si l'utilisateur est en train de clicker / évite que le programe comprenne que le click se fait toutes les step mais bien q'une seule fois
        public bool clickpressed;

        // interface graphic = à celle dans game1
        public GraphicsDevice GraphicsDevice;

        // spritebatch = a celui dans game1
        public SpriteBatch spriteBatch;

        // string permettant de savoir dans quelle screen l'utilisateur se trouve actuellement 
        public string nameLevel;

        // affiche l'instance actuelle (et les variables dédiées)
        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        // constructeur / permet d'initialiser les variables
        public ScreenManager()
        {
            // si c'est le premier lancement alors le premier screen est le menu de base
            if (instance == null)
            {
                dimensions = new Vector2(720,480);
                currentScreen = new Menu();
            }
        }

        public void LoadContent(ContentManager Content) // load content
        {
            // le content de cette classe se sert du contentprovider de game1
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            // on load le current screen
            currentScreen.LoadContent();
        }

        public void UnloadContent() // unload
        {
            // unload le current screen
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime) // update
        {
            // update du currentscreen
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) // draw
        {
            // draw le current screen
            currentScreen.Draw(spriteBatch);
        }

        public void ChangeScreens(string screenname) // fonction permettant de changer de screen
        {
            // on unload le current screen
            currentScreen.UnloadContent();
            // on créer une nouvelle instance pour le screen que l'on veut obtenir
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Slumber_Ware." + screenname));
            // on balance l'instance crée dans currentscreen pour que ce soit cette instance qui soit le currentscreen
            currentScreen = newScreen;
            // on load le current screen
            currentScreen.LoadContent();
        }
    }
}

