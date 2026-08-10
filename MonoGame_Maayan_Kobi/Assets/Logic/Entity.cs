using System.Numerics;

namespace MonoGame_Maayan_Kobi;

public class Entity : Animation
{
    protected float speedMovement;
    public Entity(string spriteName) : base(spriteName)
    {
    }

    protected void UpdatePos()
    {
        tm.position += new Vector2(speedMovement * (float)deltaTime, 0);
    }
}