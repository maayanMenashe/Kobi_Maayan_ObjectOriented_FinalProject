
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class Entity : Animation
{
    public float speedMovement;
    public Vector2 spawnPoint;
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