using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snakeGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        Texture2D fondoSnake;

        SpriteFont fuente;

        Texture2D boton;

        int opcionSeleccionada = 0;

        string[] opcionesMenu = { "Jugar", "Ajustes", "Salir" };

        KeyboardState estadoTecladoAnterior;

        public Game1() // inicializacion
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

            // Configuración para pantalla completa
            //_graphics.IsFullScreen = true;
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            fondoSnake = Content.Load<Texture2D>("fondoSnake");

            fuente = Content.Load<SpriteFont>("fuente");

            boton = Content.Load<Texture2D>("boton");
        }

        protected override void Update(GameTime gameTime)
        {

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();

                // TODO: Add your update logic here

            var estadoTeclado = Keyboard.GetState();

            if (estadoTeclado.IsKeyDown(Keys.Down) && estadoTecladoAnterior.IsKeyUp(Keys.Down))
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opcionesMenu.Length;
            }

            if (estadoTeclado.IsKeyDown(Keys.Up) && estadoTecladoAnterior.IsKeyUp(Keys.Up))
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opcionesMenu.Length) % opcionesMenu.Length;
            }

            if (estadoTeclado.IsKeyDown(Keys.Enter) || estadoTeclado.IsKeyDown(Keys.Space))
            {
                SeleccionarOpcion();
            }

            estadoTecladoAnterior = estadoTeclado;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            _spriteBatch.Draw(fondoSnake, Vector2.Zero, Color.White);

            for (int i = 0; i < opcionesMenu.Length; i++)
            {
                // Cambiar el color del botón seleccionado
                Color colorBoton = (i == opcionSeleccionada) ? Color.Yellow : Color.White;
                _spriteBatch.Draw(boton, new Rectangle(285, 160 + (i * 90), 200, 100), colorBoton);

                // Cambiar el color del texto según si está seleccionado
                Color colorTexto = (i == opcionSeleccionada) ? Color.Red : Color.Black;
                _spriteBatch.DrawString(fuente, opcionesMenu[i], new Vector2(355, 200 + (i * 90)), colorTexto);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // Función para manejar la selección de una opción
        private void SeleccionarOpcion()
        {
            switch (opcionSeleccionada)
            {
                case 0: // Jugar
                    // Lógica para comenzar el juego
                    System.Console.WriteLine("Iniciar juego");
                    break;
                case 1: // Ajustes
                    // Lógica para mostrar la pantalla de ajustes
                    System.Console.WriteLine("Abrir ajustes");
                    break;
                case 2: // Salir
                    Exit(); // Cerrar el juego
                    break;
            }
        }
    }
}
