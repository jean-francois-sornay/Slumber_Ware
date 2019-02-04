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
                currentScreen = new GameScreen(); //A FAIRE !!!!!!!!
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


        public void ChangeScreens(string screenname, int _nbrlevel, bool gagner) // fonction permettant de changer de screen
        {

            currentScreen.UnloadContent(); // on unload le current screen
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("R1TS." + screenname)); // on créer une nouvelle instance pour le screen que l'on veut obtenir
            currentScreen = newScreen; // on balance l'instance crée dans currentscreen pour que ce soit cette instance qui soit le currentscreen
            currentScreen.LoadContent(); // on load le current screen
        }
        public void Changetaillescreen(string screenname, bool manualchange, Vector2 dim, int _nbrlevel) // fonction permettant de changer de screen et de changer la taille de l'ecran
        {
            nameLevel = screenname; // on change le nom du screen pour correspondre à celui qui va prendre la place
            /*if (manualchange == true) { dimensions = dim; nbrlevel = _nbrlevel; dimensions5 = dim; } // si le changement est manuel (vient des options) alors on change de dimensions et on l'enregistre dans dimensions 5 et on donne le niveau souhaité
            else // sinon
            {
                nbrlevel = _nbrlevel; // on prend le level demandé
                if (screenname == "Menu_Base") { Dimensions = dimensions5; } // si le screen demandé est menu de base alors les dimensions de l'écran sont celle que l'utilisateur a enregistré
                else // sinon
                {
                    if (difficulty == "Normal") { Dimensions = Dimensions3; } // si la difficulté est réglé sur normal les dimensions de l'écran = dimension3
                    if (difficulty == "Hard") { Dimensions = Dimensions4; } // si la difficulté est réglé sur hard les dimensions de l'écran = dimension4
                }
            }
            size = true; // size = true donc la classe game1 va effectué le changement de taille et de screen*/
        }
    }
}

