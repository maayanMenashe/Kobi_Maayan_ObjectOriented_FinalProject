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
        Text lives = new Text();
        Text claimed = new Text();

        public void Start()
        {
            lives.font = wantedFont;
            claimed.font = wantedFont;
            lives.tm.position = new Vector2(100, 50);
            claimed.tm.position = new Vector2(200, 135);
        }

        public void Update(int incLives)
        {
            lives.text = "Lives: " + incLives;
            claimed.text = "Claimed: " + Game1._screenCenter.X;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            lives.Draw(spriteBatch);
            claimed.Draw(spriteBatch);
        }
    }
}
