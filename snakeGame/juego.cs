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
    internal class juego
    {
        private Game1 juegoPrincipal;

        private Texture2D fondoSnake;

        //private serpiente serpiente;

        //private manzana manzana;

        private SpriteFont fuente;

        private int puntuacion = 0;

        public juego(Game1 juego) 
        {
            juegoPrincipal = juego;

            //serpiente = new serpiente();

            //manzana = new manzana();
        }

        public void Initialize(ContentManager contenido) 
        {
            fondoSnake = contenido.Load<Texture2D>("fondoSnake");

            fuente = contenido.Load<SpriteFont>("fuente");
        }

        public void Update(KeyboardState teclado, ref string estadoActual)
        {
            //serpiente.Actualizar(teclado);

            //if (serpiente.ComerManzana(manzana.Posicion))
            {
                //puntuacion += 10;

                //manzana.GenerarNuevaPosicion();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondoSnake, Vector2.Zero, Color.White);

            //serpiente.Dibujar(spriteBatch);

            //manzana.Dibujar(spriteBatch);

            //spriteBatch.DrawString(fuente, $"Puntuación: {puntuacion}", new Vector2(10, 10), Color.Black);
        }
    }
}
