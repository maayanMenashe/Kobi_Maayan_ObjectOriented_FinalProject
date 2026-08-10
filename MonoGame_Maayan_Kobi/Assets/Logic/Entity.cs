using System.Numerics;

namespace MonoGame_Maayan_Kobi;

public class Entity : Animation
{
    protected float speedMovement;
    public Entity(string spriteName) : base(spriteName)
    {
    }

    // protected void UpdatePos(float x, float y)
    // {
    //     tm.position += new Vector2(x,y);
    //     destRect.X = (int)x;
    //     destRect.Y = (int)y;
    // }
}