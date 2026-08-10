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
        private Vector2 prevPos = Game1._screenCenter;
        private Vector2 nextPos;
        private Board.Status currentSquareStatus;
        private Vector2 velocity = new Vector2(1,1);
        private float deltaTime;
        

        public Qix() : base("temp-player")
        {
            speedMovement = 300;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            tm.position += new Vector2(1f,1f) * velocity * (float)deltaTime * speedMovement;
            currentSquareStatus = Utils.WhatSquareAmI(tm.position, out int curX, out int curY);
            if (Utils.IsOutOfBounds(tm.position, this) || currentSquareStatus == Board.Status.Captured)
            {
                tm.position = prevPos;
                ChangeDirection();
            }
            prevPos = tm.position;
        }



        private void ChangeDirection()
        {
            tm.position += new Vector2(1f,1f) * velocity * (float)deltaTime * speedMovement;
            Vector2 nextStep =  tm.position + new Vector2(1f,1f) * velocity * (float)deltaTime * speedMovement;
            Vector2 nextVerticalPos = new Vector2(nextStep.X, tm.position.Y);
            Vector2 nextHorizontalPos = new Vector2(tm.position.X, nextStep.Y);
            if (Utils.IsOutOfBounds(nextVerticalPos, this) || Utils.WhatSquareAmI(nextVerticalPos, out int a, out int b) == Board.Status.Captured)
            {
                velocity *= new Vector2(-1, 1);
            }
            
            if (Utils.IsOutOfBounds(nextHorizontalPos, this) || Utils.WhatSquareAmI(nextHorizontalPos, out int c, out int d) == Board.Status.Captured)
            {
                velocity *= new Vector2(1, -1);
            }
        }
    }
    
    

    

}
