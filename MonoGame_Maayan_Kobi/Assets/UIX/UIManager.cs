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
            lives.tm.position = new Vector2(100, 50);
            claimed.tm.position = new Vector2(200, 135);
            currentLevel.tm.position = new Vector2(1750, 50);
            
            //lives.tm.position = wantedFont.MeasureString(lives.text) * 0.5f;
            //currentLevel.tm.position = wantedFont.MeasureString(currentLevel.text) * 0.5f + new Vector2(Game1.ScreenWidth/2f, 0);
            //claimed.tm.position = new Vector2(Game1.ScreenWidth, 0) - wantedFont.MeasureString(claimed.text);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //lives.Draw(spriteBatch);
            //claimed.Draw(spriteBatch);
            //currentLevel.Draw(spriteBatch);
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
            lives.text = curLevel.ToString();
        }
    }
}
