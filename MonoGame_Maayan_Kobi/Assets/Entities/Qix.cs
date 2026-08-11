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
        private float deltaTime;
        
        
        

        public Qix() : base("DVDie")
        {
            spawnPoint = Game1._screenCenter;
            tm.position = spawnPoint;
            speedMovement = 300;
            
            destRect.Width /= 3;
            destRect.Height /= 3;
        }

        public override void Update(GameTime gameTime)
        {
            if (!GameStateManager.IsPaused())
            {
                base.Update(gameTime);
                deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                tm.position += new Vector2(1f,1f) * velocity * deltaTime * speedMovement;
                currentSquareStatus = Utils.CurrentSquareStatus(tm.position, out int currentSquareX, out int currentSquareY);
                if (Utils.IsOutOfBounds(tm.position, this) || currentSquareStatus == Board.Status.Captured)
                {
                    tm.position = prevPos;
                    ChangeDirection();
                }
                prevPos = tm.position;
                destRect.X = (int)tm.position.X;
                destRect.Y = (int)tm.position.Y;
            
            
                if (currentSquareStatus == Board.Status.Touched)
                    GameplayManager.PlayPlayerDeathSequence();
            }
        }



        private void ChangeDirection()
        {
            Vector2 nextStep =  tm.position + new Vector2(1f,1f) * velocity * deltaTime * speedMovement;
            Vector2 nextVerticalPos = new Vector2(nextStep.X, tm.position.Y);
            Vector2 nextHorizontalPos = new Vector2(tm.position.X, nextStep.Y);
            if (Utils.IsOutOfBounds(nextVerticalPos, this) || Utils.CurrentSquareStatus(nextVerticalPos, out int a, out int b) == Board.Status.Captured)
            {
                velocity *= new Vector2(-1, 1);
            }
            
            if (Utils.IsOutOfBounds(nextHorizontalPos, this) || Utils.CurrentSquareStatus(nextHorizontalPos, out int c, out int d) == Board.Status.Captured)
            {
                velocity *= new Vector2(1, -1);
            }
        }
    }
    
    

    

}
