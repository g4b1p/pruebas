using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daadlyWheels
{
    // clase que no se puede instanciar directamente. Sirve como una plantilla para que otras clases hereden de ella
    public abstract class Component

    // esta clase será la base de otros componentes específicos del juego, como botones, personajes, o elementos gráficos
    // las clases derivadas deben implementar los métodos abstractos definidos aquí
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        // cualquier clase que herede de Component debe proporcionar una implementación específica de este método
        /*
         GameTime: proporciona información sobre el tiempo transcurrido, útil para controlar las animaciones y la lógica basada en el tiempo
         SpriteBatch: se utiliza para dibujar sprites (imágenes 2D) en la pantalla
         */

        public abstract void Update(GameTime gameTime);
        // es donde se actualiza la lógica del componente (por ejemplo, para mover objetos, responder a la entrada del usuario, o cambiar el estado del componente)
        // GameTime: podrías usarlo para hacer que un componente se mueva más lentamente o más rápido, dependiendo de cuánto tiempo haya pasado
    }
}