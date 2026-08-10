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

    
    public static Board.Status WhatSquareAmI(Vector2 pos ,out int xPos, out int yPos) //Checks the current status of the square on the grid
    {
        Vector2 currentSquarePos = CheckCurrentSquare(pos);
        xPos = (int)currentSquarePos.X;
        yPos = (int)currentSquarePos.Y;
        return Board.grid[xPos, yPos];
    }
    

    public static bool IsOutOfBounds(Vector2 currentPos, Sprite thisSprite) //Checks if the current position is outside the play bounds
    {
        if (currentPos.X < 0 || currentPos.Y < 0 || currentPos.X > Game1.ScreenWidth - thisSprite.texture.Width/2f|| currentPos.Y > Game1.ScreenHeight - thisSprite.texture.Height/2f)
        {
            return true;
        }
        return false;

    }
    

}