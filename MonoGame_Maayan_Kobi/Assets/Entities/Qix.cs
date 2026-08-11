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
        
        public Qix() : base("DVDie")
        {
            spawnPoint = Game1._screenCenter;
            tm.position = spawnPoint;
            speedMovement = 300;
            forbiddenSquareStatus = Board.Status.Captured;
        }

        public override void Update(GameTime gameTime)
        {
            if (!GameStateManager.IsPaused())
            {
                base.Update(gameTime);
                if (currentSquareStatus == Board.Status.Touched)
                    GameplayManager.PlayPlayerDeathSequence();
            }
        }
    }
    
    

    

}
