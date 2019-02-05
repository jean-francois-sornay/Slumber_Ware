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

        private ContentManager content; // content servant pour le content de la classe gamescreen et de ses classes filles
        public ContentManager Content { get { return content; } private set { content = value; } }

        GameScreen currentScreen, newScreen; // variable de gamescreen: currentscreen permet de faire les actions du screen actuelle / newscreen permet de changer de screen

        private Vector2 Dimensions; // vecteur 2 dimension permettant de définir la taille de la fenêtre
        public Vector2 dimensions { get { return Dimensions; } set { Dimensions = value; } }

        private bool Size = false; // variable permettant de savoir si il faut changer de taille l'écran (false = non)
        public bool size { get { return Size; } set { Size = value; } }

        private MouseState MouseState; // variable permettant d'avoir l'état de la souris
        public MouseState mouseState { get { return MouseState; } set { MouseState = value; } }

        private bool ClickPressed; // variable permettant de savoir si l'utilisateur est en train de clicker / évite que le programe comprenne que le click se fait toutes les step mais bien q'une seule fois
        public bool clickpressed { get { return ClickPressed; } set { ClickPressed = value; } }

        private GraphicsDevice graphicsDevice; // interface graphic = à celle dans game1
        public GraphicsDevice GraphicsDevice { get { return graphicsDevice; } set { graphicsDevice = value; } }

        public SpriteBatch spriteBatch { get { return SpriteBatch; } set { SpriteBatch = value; } }
        private SpriteBatch SpriteBatch; // spritebatch = a celui dans game1

        private float Volume = 0.01f; // variable du volume de tout ce qui est audio
        public float volume { get { return Volume; } set { Volume = value; } }

        private string NameLevel; // string permettant de savoir dans quelle screen l'utilisateur se trouve actuellement 
        public string nameLevel { get { return NameLevel; } set { NameLevel = value; } }

        public static ScreenManager Instance // affiche l'instance actuelle (et les variables dédiées)
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

        public ScreenManager() // constructeur / permet d'initialiser les variables
        {
            if (instance == null) // si c'est le premier lancement alors le premier screen est le menu de base
            {
                dimensions = new Vector2(720,480);
                currentScreen = new Scene_de_base(); //A FAIRE !!!!!!!!
            }
        }

        public void LoadContent(ContentManager Content) // load content
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content"); // le content de cette classe se sert du contentprovider de game1
            currentScreen.LoadContent(); // on load le current screen
        }

        public void UnloadContent() // unload
        {
            currentScreen.UnloadContent(); // unload le current screen
        }

        public void Update(GameTime gameTime) // update
        {
            currentScreen.Update(gameTime); // update du currentscreen
        }

        public void Draw(SpriteBatch spriteBatch) // draw
        {
            currentScreen.Draw(spriteBatch); // draw le current screen
        }

        public void ChangeScreens(string screenname) // fonction permettant de changer de screen
        {
            currentScreen.UnloadContent(); // on unload le current screen
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Slumber_Ware." + screenname)); // on créer une nouvelle instance pour le screen que l'on veut obtenir
            currentScreen = newScreen; // on balance l'instance crée dans currentscreen pour que ce soit cette instance qui soit le currentscreen
            currentScreen.LoadContent(); // on load le current screen
        }
    }
}

