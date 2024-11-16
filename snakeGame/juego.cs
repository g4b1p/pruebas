using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snakeGame
{
    internal class juego
    {
        private Game1 juegoPrincipal;

        private Texture2D fondoSnake;
        private SpriteFont fuente;

        public juego(Game1 juego)
        {
            juegoPrincipal = juego;
        }

        public void Initialize(ContentManager contenido)
        {
            fondoSnake = contenido.Load<Texture2D>("fondoSnake");
            fuente = contenido.Load<SpriteFont>("fuente");
        }

        public void Update(KeyboardState teclado, ref string estadoActual)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondoSnake, new Rectangle(0, 0, juegoPrincipal.pantallaAncho, juegoPrincipal.pantallaAltura), Color.White);
        }
    }
}
