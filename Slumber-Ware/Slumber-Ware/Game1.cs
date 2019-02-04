using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slumber_Ware
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.dimensions.X; // la longueur de la fenêtre est = au dimension sur X de ScreenManager.Instance.dimensions
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.dimensions.Y; // la hauteur de la fenêtre est = au dimension sur Y de ScreenManager.Instance.dimensions
            graphics.ApplyChanges(); // on applique les changements
            IsMouseVisible = true; // variable disant que la souris est visible quand elle passe dans la fenetre créer par le jeu
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice); // créer un spritebatch ce qui permet de draw les images
            ScreenManager.Instance.GraphicsDevice = GraphicsDevice; // Le graphicsdevice de screenmanager est le meme que celui ci
            ScreenManager.Instance.spriteBatch = spriteBatch; // Le spriteBatch de screenmanager est le meme que celui ci
            ScreenManager.Instance.LoadContent(Content); // load le content de screenmanager
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent(); // unload le content de screenmanager
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) // si on appuie sur la touche espace alors on quitte le jeu
            { Exit(); }

            if (ScreenManager.Instance.size == true) // si screenmanager size == true alors c'est qu'on doit changer la taille
            {
                ScreenManager.Instance.size = false; // la taille a bien changé
                graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.dimensions.X; // on met la taille demandé en longueur
                graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.dimensions.Y; // on met la taille demandé en hauteur
                graphics.ApplyChanges(); // on applique les changements
                ScreenManager.Instance.ChangeScreens(ScreenManager.Instance.nameLevel, 0, true); // pour que cela ne bug pas on est obligé de relancer la classe 
            }
            ScreenManager.Instance.Update(gameTime); // update tout ce qu'il y a dans ScreenManager.Instance.Update
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); // nettoie l'arrière plan en noir
            spriteBatch.Begin(); // commence à draw
            ScreenManager.Instance.Draw(spriteBatch); // draw tout ce qu'il y a dans ScreenManager.Instance.Daw
            spriteBatch.End(); // fini de draw
            base.Draw(gameTime);
        }
    }
}
