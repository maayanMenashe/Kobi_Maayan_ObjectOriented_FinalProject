using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Maayan_Kobi;

public class MousePositionText : Text
{
    public MousePositionText() : base("Oswald")
    {
    }

    public override void Start()
    {

        tm.position = new Vector2(Game1._screenCenter.X, 50);
    }

    public override void Update(GameTime gameTime)
    {
       text = Mouse.GetState().Position.ToString();  
    }
}