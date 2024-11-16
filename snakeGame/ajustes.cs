using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snakeGame
{
    internal class ajustes
    {
        private Game1 juegoPrincipal;

        private Texture2D fondoSnake;
        private Texture2D boton;
        private SpriteFont fuente;

        private bool sonidoActivado = false;

        private string[] opciones = { "volumen", "volver" };

        KeyboardState estadoTecladoAnterior;
        private int opcionSeleccionada = 0;

        public ajustes(Game1 juego)
        {
            juegoPrincipal = juego;
        }

        public void Initialize(ContentManager contenido)
        {
            fondoSnake = contenido.Load<Texture2D>("fondoSnake");
            boton = contenido.Load<Texture2D>("boton");
            fuente = contenido.Load<SpriteFont>("fuente");
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
                    sonidoActivado = !sonidoActivado;
                }
                else if (opcionSeleccionada == 1)
                {
                    estadoActual = "menu";
                }
            }
            estadoTecladoAnterior = estadoTeclado;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondoSnake, new Rectangle(0, 0, juegoPrincipal.pantallaAncho, juegoPrincipal.pantallaAltura), Color.White);

            for (int i = 0; i < opciones.Length; i++)
            {
                Color colorBoton = (i == opcionSeleccionada) ? Color.Yellow : Color.White;
                spriteBatch.Draw(boton, new Rectangle((juegoPrincipal.pantallaAncho - 400) / 2, 340 + (i * 180), 400, 200), colorBoton);

                Color colorTexto = (i == opcionSeleccionada) ? Color.Red : Color.Black;
                spriteBatch.DrawString(fuente, opciones[i], new Vector2((juegoPrincipal.pantallaAncho - fuente.MeasureString(opciones[i]).X) / 2, 410 + (i * 180)), colorTexto);
            }

            var colorVolumenBoton = sonidoActivado ? Color.DarkGreen : Color.Red;
            spriteBatch.Draw(boton, new Rectangle((juegoPrincipal.pantallaAncho - 400) / 2, 340, 400, 200), colorVolumenBoton);

            var colorTextoVolumen = sonidoActivado ? Color.LightGreen : Color.OrangeRed;
            spriteBatch.DrawString(fuente, "volumen", new Vector2((juegoPrincipal.pantallaAncho - 200) / 2, 410), colorTextoVolumen);
        }
    }
}