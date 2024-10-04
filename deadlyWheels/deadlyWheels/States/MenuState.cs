using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using daadlyWheels.Controls;

namespace daadlyWheels.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        // lista privada de Component, donde se almacenan todos los componentes interactivos (como botones) que forman parte del menú

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content) // constructor
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button"); 
            // carga una textura de imagen para el botón desde la carpeta Controls/Button

            var buttonFont = _content.Load<SpriteFont>("Fonts/Font"); 
            // carga una fuente de texto desde la carpeta Fonts/Font

            var newGameButton = new Button(buttonTexture, buttonFont) // creo una instancia de la clase Button
            {
                Position = new Vector2(300, 200), // coordenadas
                Text = "Jugar", // texto
            };

            newGameButton.Click += NewGameButton_Click;
            // cuando el jugador haga clic en el btn, se ejecutará el método NewGameButton_Click

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Ajustes",
            };

            loadGameButton.Click += LoadGameButton_Click;
            // cuando el jugador haga clic en el btn, se ejecutará el método LoadGameButton_Click

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 300),
                Text = "Salir",
            };

            quitGameButton.Click += QuitGameButton_Click;
            // cuando el jugador haga clic en el btn, se ejecutará el método QuitGameButton_Click

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            }; // lista que guarda los btns
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(); // inicia proceso de dibujo
            foreach (var c in _components)
            {
                c.Draw(gameTime, spriteBatch); // dibuja cada btn
            }
            spriteBatch.End(); // termina 
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ajustes del juego"); // btn q deberia ir la logica de los ajustes --[se deberia crear otro estado para ajustes]--
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content)); // btn q cambia a la logica del juego
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit(); // btn para salir del juego
        }

        public override void PostUpdate(GameTime gameTime)
        {
            /*
             metodo para lógica que debe ejecutarse después de Update. Está vacío en este caso, pero se podría usar 
            para remover componentes no necesarios (por ejemplo, si quieres eliminar un botón cuando ya no es relevante)
             */
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var c in _components)
            {
                c.Update(gameTime);
                // para que puedan manejar actualizaciones (por ejemplo, detectar si el usuario hizo clic en un botón)
            }
        }
    }
}