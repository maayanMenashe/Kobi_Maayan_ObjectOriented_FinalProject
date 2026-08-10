using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi.Assets.UIX
{
    public class UIMain: IUpdatable, IDrawable
    {
        public SpriteFont wantedFont;
        Text lives = new Text();

        public void Start()
        {
            lives.font = wantedFont;
            lives.text = "lmao";
        }

        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            lives.Draw(spriteBatch);
        }
    }
}
