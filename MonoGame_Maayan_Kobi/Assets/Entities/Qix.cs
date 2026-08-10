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
        Vector2 direction = new Vector2();
        private Vector2 prevPosition = Game1._screenCenter;
        
        
        public override void Update(GameTime gameTime)
        {
            if (Utils.IsOutOfBounds(tm.position, prevPosition, this))
            {
                tm.position =  prevPosition;
            }
            prevPosition =  tm.position;
        }
        
        
        
        protected override void Action(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            tm.position += direction * speedMovement * deltaTime; 
            //insert collision logic here
        }
    }
    

}
