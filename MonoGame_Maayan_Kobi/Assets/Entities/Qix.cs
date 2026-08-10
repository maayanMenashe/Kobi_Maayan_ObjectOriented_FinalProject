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
        private float deltaTime;
        int vertiDelta = 1, HorizDelta = 1;
        Vector2 velocity = new Vector2(1,1);
        private Vector2 prevPos = Game1._screenCenter;
        private Vector2 nextPos;
        private Board.Status currentSquareStatus;

        public Qix() : base("temp-player")
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); 
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            currentSquareStatus = Utils.WhatSquareAmI(tm.position, out int curX, out int curY);
            if (Utils.IsOutOfBounds(tm.position, prevPos, this) || currentSquareStatus == Board.Status.Captured)
            {
                tm.position = prevPos;
            }
            
            prevPos = tm.position;

            
            tm.position += new Vector2(speedMovement * deltaTime, speedMovement * deltaTime) * velocity;
        }
    }
    

}
