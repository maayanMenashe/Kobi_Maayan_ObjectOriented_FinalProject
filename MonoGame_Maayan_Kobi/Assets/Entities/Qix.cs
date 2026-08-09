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
        protected override void Action(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            tm.position += new Vector2(0, speedMovement * deltaTime); 
            //insert collision logic here
        }
    }
}
