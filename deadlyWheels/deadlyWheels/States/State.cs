using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daadlyWheels.States
{
    // esta clase servirá como base para diferentes estados del juego (como MenuState, GameState, etc)
    // al ser abstracta, no se puede instanciar directamente, pero otras clases heredarán de ella y proporcionarán implementaciones específicas de los métodos abstractos
    public abstract class State
    {
        // marcan una región de código que se puede colapsar en algunos editores, lo que mejora la legibilidad al agrupar secciones del código
        #region Fields

        protected ContentManager _content;
        // permite a las clases que hereden de State acceder al gestor de contenido para cargar texturas, sonidos, etc

        protected GraphicsDevice _graphicsDevice;
        // es la referencia al dispositivo gráfico usado para renderizar los gráficos del juego

        protected Game1 _game;
        // guarda una referencia a la clase principal del juego (Game1). Esto permitirá a los diferentes estados interactuar con el juego global, si es necesario

        #endregion



        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        // lo mismo q en Component

        public abstract void PostUpdate(GameTime gameTime);
        // lo mismo q en Game1

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) // constructor
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        public abstract void Update(GameTime gameTime);
        // lo mismo q en Component

        #endregion
    }
}