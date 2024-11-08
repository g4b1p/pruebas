using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            spriteBatch.Draw(fondoSnake, Vector2.Zero, Color.White);

            for (int i = 0; i < opciones.Length; i++)
            {
                Color colorBoton = (i == opcionSeleccionada) ? Color.Yellow : Color.White;

                spriteBatch.Draw(boton, new Rectangle(285, 160 + (i * 90), 220, 110), colorBoton);

                Color colorTexto = (i == opcionSeleccionada) ? Color.Red : Color.Black;

                spriteBatch.DrawString(fuente, opciones[i], new Vector2(355, 200 + (i * 90)), colorTexto);
            }

            var colorVolumenBoton = sonidoActivado ? Color.DarkGreen : Color.Red;

            spriteBatch.Draw(boton, new Rectangle(285, 160, 220, 110), colorVolumenBoton);

            var colorTextoVolumen = sonidoActivado ? Color.LightGreen : Color.OrangeRed;

            spriteBatch.DrawString(fuente, "volumen", new Vector2(355, 200), colorTextoVolumen);
        }
    }
}