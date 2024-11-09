using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snakeGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        menuPrincipal menu;

        juego juego;

        ajustes ajustes;

        string estadoActual;

        public Game1() // inicializacion
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            //_graphics.IsFullScreen = true;

            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            
            //_graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            menu = new menuPrincipal(this);

            juego = new juego(this);

            ajustes = new ajustes(this);

            estadoActual = "menu"; // Inicia en el menú principal

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            menu.Initialize(Content);

            juego.Initialize(Content);

            ajustes.Initialize(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();
            // TODO: Add your update logic here

            var teclado = Keyboard.GetState();

            if (estadoActual == "menu")
            {
                menu.Update(teclado, ref estadoActual);
            }
            else if (estadoActual == "jugando")
            {
                juego.Update(teclado, ref estadoActual);
            }
            else if (estadoActual == "ajustes")
            {
                ajustes.Update(teclado, ref estadoActual);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here

            if (estadoActual == "menu")
            {
                menu.Draw(_spriteBatch);
            }
            else if (estadoActual == "jugando")
            {
                juego.Draw(_spriteBatch);
            }
            else if (estadoActual == "ajustes")
            {
                ajustes.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
