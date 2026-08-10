using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public static class Utils
{
    public static Vector2 CheckCurrentSquare(Vector2 pos) //Checks with Vector2 where the player is in the grid
    {
        float X = pos.X / Board.singleSquareWidth;
        float Y = pos.Y / Board.singleSquareHeight;
        return new Vector2(X, Y);
    }

    public static Board.Status WhatSquareAmI(Transform tm) //Checks the current status of the square on the grid
    {
        Vector2 currentSquarePos = Utils.CheckCurrentSquare(tm.position);
        int currentSquareX = (int)currentSquarePos.X;
        int currentSquareY = (int)currentSquarePos.Y;
        return Board.grid[currentSquareX, currentSquareY];
    }

    public static bool IsOutOfBounds(Vector2 currentPos, Vector2 prevPos, Sprite thisSprite) //Checks if the current position is outside the play bounds
    {
        if (currentPos.X < 0 || currentPos.Y < 0 || currentPos.X > Game1.ScreenWidth - thisSprite.texture.Width/2f + 15|| currentPos.Y > Game1.ScreenHeight - thisSprite.texture.Height/2f - 10)
        {
            return true;
        }
        return false;

    }
    

}