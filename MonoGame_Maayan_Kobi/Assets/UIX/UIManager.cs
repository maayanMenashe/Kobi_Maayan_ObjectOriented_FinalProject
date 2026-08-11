using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi
{
    public class UIManager: IDrawable
    {
        public SpriteFont wantedFont;
        public static Text lives = new Text();
        public static Text claimed = new Text();
        public static Text currentLevel = new Text();

        public void Start()
        {
            lives.font = wantedFont;
            claimed.font = wantedFont;
            currentLevel.font = wantedFont;

            RemainingLives(GameplayManager.PlayerLives);
            CurrentLevel(LevelManager.currentLevel.levelNum);
            
            lives.tm.position = new Vector2(100, 50);
            claimed.tm.position = new Vector2(1650, 50);
            currentLevel.tm.position = new Vector2(900, 30);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // lives.Draw(spriteBatch);
            // claimed.Draw(spriteBatch);
            // currentLevel.Draw(spriteBatch);
        }
        public static void ClaimedPercentage(int cur, int goal)
        {
            claimed.text = "Claimed: " + cur.ToString() + "% /" + goal.ToString() + "%";
        }
        public static void RemainingLives(int incLives)
        {
            lives.text = "Lives: " + incLives.ToString();
        }
        public static void CurrentLevel(int curLevel)
        {
            currentLevel.text = curLevel.ToString();
        }
    }
}
