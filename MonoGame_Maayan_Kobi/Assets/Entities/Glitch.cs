using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Maayan_Kobi
{
    public class Glitch : Enemy
    {
        public Glitch() : base("Glitch")
        {
            spawnPoint = new Vector2(Game1.ScreenWidth - 10, Game1.ScreenHeight - 10);
            tm.position = spawnPoint;
            speedMovement = 200;
            spawningLevel = 3;
            forbiddenSquareStatus = Board.Status.Uncaptured;
        }
    }
}
