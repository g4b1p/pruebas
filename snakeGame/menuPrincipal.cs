using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace snakeGame
{
    internal class menuPrincipal
    {
        private SpriteFont fuente;

        private Texture2D boton;

        private Texture2D fondoSnake;

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
            spriteBatch.Draw(fondoSnake, Vector2.Zero, Color.White);

            for (int i = 0; i < opciones.Length; i++)
            {
                var colorBoton = (i == opcionSeleccionada) ? Color.Yellow : Color.White;

                spriteBatch.Draw(boton, new Rectangle(285, 160 + (i * 90), 200, 100), colorBoton);
                
                var colorTexto = (i == opcionSeleccionada) ? Color.Red : Color.Black;
                
                spriteBatch.DrawString(fuente, opciones[i], new Vector2(355, 200 + (i * 90)), colorTexto);
            }
        }
    }
}
