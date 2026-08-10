using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi.Assets.UIX
{
    public class UIMain: IDrawable
    {
        public SpriteFont wantedFont;
        static Text lives = new Text();
        static Text claimed = new Text();
        static Text currentLevel = new Text();

        public void Start()
        {
            lives.font = wantedFont;
            claimed.font = wantedFont;
            currentLevel.font = wantedFont;
            lives.tm.position = new Vector2(100, 50);
            claimed.tm.position = new Vector2(200, 135);
            currentLevel.tm.position = new Vector2(1750, 50);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            lives.Draw(spriteBatch);
            claimed.Draw(spriteBatch);
            currentLevel.Draw(spriteBatch);
        }
        public static void ClaimedPercentage(int cur, int goal)
        {
            claimed.text = "Claimed: " + cur.ToString() + "/" + goal.ToString();
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
