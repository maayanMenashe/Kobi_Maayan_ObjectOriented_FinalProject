using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public static class Utils
{
    public static Vector2 CheckCurrentSquare(Sprite sprite)
    {
        float X = sprite.tm.position.X / Board.singleSquareWidth;
        float Y = sprite.tm.position.Y / Board.singleSquareHeight;
        return new Vector2(X, Y);
    }
}