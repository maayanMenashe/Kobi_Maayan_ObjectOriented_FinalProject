using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi
{
    public class Qix: Enemy
    {
        float speedMovement = 300;
        Vector2 velocity = new Vector2();
        private Vector2 prevPos = Game1._screenCenter;
        
        protected override void Action(GameTime gameTime)
        {
            if (Utils.IsOutOfBounds(tm.position, prevPos, this))
                tm.position = prevPos;
            prevPos = tm.position;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (true)
            {

            }
            if (true)
            {

            }
            if (true)
            {

            }
            if (true)
            {

            }

            tm.position += velocity * speedMovement * deltaTime; 
            //insert collision logic here
        }
    }
    

}
