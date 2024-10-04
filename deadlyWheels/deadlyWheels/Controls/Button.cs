using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daadlyWheels.Controls
{
    public class Button : Component
    {
        #region Fields

        private MouseState _currentMouse; // gurada el estado actual del ratón (posición, botones presionados, etc)
        private SpriteFont _font; // fuente de texto que será usa para dibujar en el btn
        private bool _isHovering; // booleano que indica si el ratón está sobre el btn
        private MouseState _previousMouse; // almacena el estado anterior del ratón, para detectar cambios como la liberación de un btn
        private Texture2D _texture; // guarda la textura (imagen) del btn

        #endregion



        #region Properties

        public event EventHandler Click; // se disparará cuando el btn sea clicado
        public bool Clicked { get; private set; } // indica si el botón fue clicado, solo puede ser modificada dentro de la clase (private set)
        public Color PenColour { get; set; } // color del texto que se dibujara en el btn, puede ser modificado desde fuera de la clase
        public Vector2 Position { get; set; } // define la posición del btn en la pantalla

        public Rectangle Rectangle 
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        /* calcula y devuelve un Rectangle basado en la posición del btn y las dimensiones de su textura,
           esto para detectar colisiones, como cuando el ratón está sobre el btn
        */

        public string Text { get; set; } // texto que se mostrará sobre el btn

        #endregion



        #region Methods

        public Button(Texture2D texture, SpriteFont font) // constructor
        {
            _texture = texture;
            _font = font;
            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White; // color por defecto para el btn
            
            if (_isHovering) // el ratón esta sobre un btn
            {
                colour = Color.DarkCyan;
            }

            spriteBatch.Draw(_texture, Rectangle, colour);
            // dibuja la textura del botón usando las coordenadas del Rectangle y el color definido

            if (!string.IsNullOrEmpty(Text)) // si el texto del btn no esta vacío, lo dibujo..
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState(); // obtiene el estado actual del ratón (posición y estado de los botones)

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            // crea un Rectangle que representa la posición actual del ratón. Es un rectángulo de 1x1 píxeles en las coordenadas del ratón

            _isHovering = false;

            // verifica si el Rectangle del ratón intersecta con el Rectangle del btn, es decir, si el ratón está encima del btn
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                // verifica si el usuario ha hecho clic (presionado y liberado el btn izquierdo del ratón)
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                    // si se ha hecho clic, dispara el evento Click, notificando a cualquier suscriptor que el btn ha sido clicado --?
                }
            }
        }

        #endregion
    }
}