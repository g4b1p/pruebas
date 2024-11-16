using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snakeGame
{
    internal class menuPrincipal
    {
        private SpriteFont fuente;
        private Texture2D boton;
        private Texture2D fondoSnake;
        private SpriteFont titulo;

        int opcionSeleccionada = 0;
        string[] opciones = { "jugar", "ajustes", "salir" };
        KeyboardState estadoTecladoAnterior;

        private Game1 juegoPrincipal;

        public menuPrincipal(Game1 juego)
        {
            juegoPrincipal = juego;
        }

        public void Initialize(ContentManager contenido)
        {
            boton = contenido.Load<Texture2D>("boton");
            fondoSnake = contenido.Load<Texture2D>("fondoSnake");
            fuente = contenido.Load<SpriteFont>("fuente");
            titulo = contenido.Load<SpriteFont>("titulo");
        }

        public void Update(KeyboardState teclado, ref string estadoActual)
        {
            var estadoTeclado = Keyboard.GetState();

            if (estadoTeclado.IsKeyDown(Keys.Down) && estadoTecladoAnterior.IsKeyUp(Keys.Down))
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opciones.Length;
            }

            if (estadoTeclado.IsKeyDown(Keys.Up) && estadoTecladoAnterior.IsKeyUp(Keys.Up))
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opciones.Length) % opciones.Length;
            }

            if (estadoTeclado.IsKeyDown(Keys.Enter) && estadoTecladoAnterior.IsKeyUp(Keys.Enter))
            {
                if (opcionSeleccionada == 0)
                {
                    estadoActual = "jugando";
                }

                if (opcionSeleccionada == 1)
                {
                    estadoActual = "ajustes";
                }

                if (opcionSeleccionada == 2)
                {
                    juegoPrincipal.Exit();
                }
            }
            estadoTecladoAnterior = estadoTeclado;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondoSnake, new Rectangle(0, 0, juegoPrincipal.pantallaAncho, juegoPrincipal.pantallaAltura), Color.White);

            string tituloTexto = "Snake Game";
            Vector2 tamañoTitulo = titulo.MeasureString(tituloTexto);
            spriteBatch.DrawString(titulo, tituloTexto, new Vector2(960 - tamañoTitulo.X / 2, 210), Color.Red);

            for (int i = 0; i < opciones.Length; i++)
            {
                var colorBoton = (i == opcionSeleccionada) ? Color.Yellow : Color.White;
                spriteBatch.Draw(boton, new Rectangle((juegoPrincipal.pantallaAncho - 400) / 2, 340 + (i * 180), 400, 200), colorBoton);

                var colorTexto = (i == opcionSeleccionada) ? Color.Red : Color.Black;
                spriteBatch.DrawString(fuente, opciones[i], new Vector2((juegoPrincipal.pantallaAncho - fuente.MeasureString(opciones[i]).X) / 2, 410 + (i * 180)), colorTexto);
            }
        }
    }
}
