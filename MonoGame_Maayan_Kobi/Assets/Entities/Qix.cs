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
        int vertiDelta = 1, HorizDelta = 1;
        Vector2 velocity = new Vector2(1,1);
        private Vector2 prevPos = Game1._screenCenter;
        
        protected override void Action(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Board.Status currentSquareStatus = Utils.WhatSquareAmI(tm.position, out int curX, out int curY);
            if (Utils.IsOutOfBounds(tm.position, prevPos, this) || currentSquareStatus != Board.Status.Captured)
                tm.position = prevPos;
            prevPos = tm.position;
            /*
            if (true) // vertical
            {
                vertiDelta = 1;
                velocity.X = vertiDelta;
            }
            if (true)
            {
                vertiDelta = -1;
                velocity.X = vertiDelta;
            }
            if (true)// horizontal
            {
                HorizDelta = 1;
                velocity.Y = HorizDelta;
            }
            if (true)
            {
                HorizDelta = -1;
                velocity.Y = HorizDelta;
            }
            */
            tm.position += velocity; 
        }
    }
    

}
