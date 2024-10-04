using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using daadlyWheels.States;

namespace daadlyWheels
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics; // declara un objeto que maneja el dispositivo gráfico. Se usa para configurar la pantalla y los gráficos
        SpriteBatch spriteBatch; // declara un objeto que permite dibujar múltiples sprites

        
        // State -> clase creada en daadlyWheels.States.State
        private State _currentState; // declara una variable para almacenar el estado actual del juego (ej, el menu, un nivel, etc) --?
        private State _nextState; // declara una variable para almacenar el próximo estado al que se desea cambiar --?


        public void ChangeState(State state) // metodo para cambiar el estado
        {
            _nextState = state;
            // recibe un objeto de tipo State y lo asigna a _nextState. Este método será utilizado
            // para transitar entre diferentes estados del juego (ej, del menu al juego)
        }


        public Game1() // constructor 
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // establece el directorio raíz donde se almacenará el contenido (imágenes, sonidos, etc.) del juego --?
        }


        protected override void Initialize() // inicialización
        {
            IsMouseVisible = true;
            base.Initialize();
        }


        protected override void LoadContent() // carga de contenido
        {
            spriteBatch = new SpriteBatch(GraphicsDevice); 
            // crea una nueva instancia de SpriteBatch utilizando el dispositivo gráfico actual, lo que permite dibujar texturas en la pantalla

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            // inicializa el estado actual del juego, en este caso un MenuState. Se pasa this para referirse a la instancia actual de Game1,
            // así como el dispositivo gráfico y el administrador de contenido --?
        }

        
        protected override void UnloadContent() // descartar contenido
        {
            // TODO: Unload any non ContentManager content here

            // para liberar cualquier contenido específico del juego que no esté gestionado por el ContentManager --?
        }

        
        protected override void Update(GameTime gameTime) // actualización del juego
        {
            // para actualizar la lógica del juego, como la entrada del usuario y la lógica del juego

            if (_nextState != null) // si hay un nuevo estado al que cambiar...
            {
                _currentState = _nextState; // cambia el estado del juego
                _nextState = null; // restablece _nextState a null después de haberlo asignado
            }

            _currentState.Update(gameTime); 
            // llama al método Update del estado actual para que realice su lógica de actualización

            _currentState.PostUpdate(gameTime); 
            // llama a un método que puede ser usado para la lógica que necesita ocurrir después de la actualización principal, como la gestión de animaciones

            base.Update(gameTime); 
            // llama al método de actualización de la clase base para manejar cualquier lógica adicional necesaria --?
        }

        
        protected override void Draw(GameTime gameTime) // dibujo en la pantalla
        {
            GraphicsDevice.Clear(Color.SpringGreen); // limpia la pantalla y la establece en un color antes de dibujar
            _currentState.Draw(gameTime, spriteBatch); // llama al método Draw del estado actual, pasa gameTime y spriteBatch para que dibuje en la pantalla

            base.Draw(gameTime); // llama al método de dibujo de la clase base para realizar cualquier operación adicional de dibujo que pueda ser necesaria --?
        }
    }
}