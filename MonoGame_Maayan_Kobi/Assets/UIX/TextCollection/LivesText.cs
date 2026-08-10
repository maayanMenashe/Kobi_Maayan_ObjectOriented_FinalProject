using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_Maayan_Kobi
{
    public class LivesText : Text
    {
        public override void Start()
        {
            tm.position = new Vector2(Game1._screenCenter.X, 50);
        }

        public override void Update(GameTime gameTime)
        {
            text = Mouse.GetState().Position.ToString();
        }
    }
}
