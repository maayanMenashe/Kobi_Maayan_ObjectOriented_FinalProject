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
        public override void Update(GameTime gameTime)
        {
            MovementLogic(gameTime);
        }
        protected override void MovementLogic(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            tm.position += new Vector2(0, speedMovement * deltaTime);
        }
    }
}
