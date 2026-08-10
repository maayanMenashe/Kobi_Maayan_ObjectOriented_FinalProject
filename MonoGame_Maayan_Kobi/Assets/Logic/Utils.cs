using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public static class Utils
{
    public static Vector2 CheckCurrentSquare(Vector2 pos)
    {
        float X = pos.X / Board.singleSquareWidth;
        float Y = pos.Y / Board.singleSquareHeight;
        return new Vector2(X, Y);
    }

    public static bool IsOutOfBounds(Vector2 currentPos, Vector2 prevPos, Sprite thisSprite)
    {
        if (currentPos.X < 0 || currentPos.Y < 0 || currentPos.X > Game1.ScreenWidth - thisSprite.texture.Width/2f + 15|| currentPos.Y > Game1.ScreenHeight - thisSprite.texture.Height/2f - 10)
        {
            return true;
        }
        return false;

    }
    

}