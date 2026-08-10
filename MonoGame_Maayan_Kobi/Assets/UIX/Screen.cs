using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi
{
    public class Screen: IUpdatable, IDrawable
    {
        public Texture2D bg;
        public SpriteFont wantedFont;
        protected Text text = new Text();

        public void Start()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Vector2(0, 0), Color.White);
            text.Draw(spriteBatch);
        }
    }
}
