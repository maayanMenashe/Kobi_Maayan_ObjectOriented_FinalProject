using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Maayan_Kobi;

public class Board : Sprite
{
    
    #region StatusEnum

    public enum Status
    {
        Uncaptured,
        Touched,
        Enemy,
        Captured
    }

    #endregion

    #region Variables

    // const
    public const int numOfRows = 20;
    public const int numOfColumns = 20;
    private const string spriteName = "captured-area";
    
    // Private
    public static float singleSquareWidth;
    public static float singleSquareHeight;
    private Spritesheet capturedBackground = new Spritesheet();

    private static int numOfWalls;
    
    // Public
    
    
    // The Board
    public static Status[,] grid;
    public static HashSet<Vector2> notCaptured = new HashSet<Vector2>();
    public static HashSet<Vector2> captured = new HashSet<Vector2>();
    public static HashSet<Vector2> touched = new HashSet<Vector2>();

    
    #endregion

    #region Constructor

    public Board() : base(spriteName)
    {
        ResetBoard();
        capturedBackground.rows = numOfRows;
        capturedBackground.columns = numOfColumns;
        capturedBackground.texture = texture;
        singleSquareWidth = Game1.ScreenWidth / numOfColumns;
        singleSquareHeight = Game1.ScreenHeight / numOfRows;
        GameplayManager.playerDied += OnPlayerDeath;
    }

    #endregion
    
    public void InitBoard()
    {
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfColumns; j++)
            {
                notCaptured.Add(new Vector2(i, j));
                if (i == 0 || i == numOfRows - 1 || j == 0 || j == numOfColumns - 1)
                {
                    CaptureSquare(i, j);
                }
            }
        }

        numOfWalls = captured.Count;
    }


    public void ResetBoard()
    {
        GameplayManager.playerDied -= OnPlayerDeath;
        captured.Clear();
        notCaptured.Clear();
        touched.Clear();
        grid = new Status[numOfRows, numOfColumns];
        InitBoard();
    }

    public static void CaptureSquare(int row, int column)
    {
        grid[row, column] = Status.Captured;
        notCaptured.Remove(new Vector2(row, column));
        captured.Add(new Vector2(row, column));
    }

    public static void OnPlayerReachedSafety()
    {
        foreach (var vector in notCaptured)
        {
            if (grid[(int)vector.X, (int)vector.Y] != Status.Enemy)
            {
                CaptureSquare((int)vector.X, (int)vector.Y);
            }
            else
            {
                grid[(int)vector.X, (int)vector.Y] = Status.Uncaptured;
            }
        }
        touched.Clear();
    }

    private void OnPlayerDeath()
    {
        foreach (var vector in notCaptured)
        {
            int x = (int)vector.X;
            int y = (int)vector.Y;
            if (grid[x,y] == Status.Touched)
            {
                grid[x, y] = Status.Uncaptured;
            }
        }
        touched.Clear();
    }
    
    public static bool IsGoalPercentageReached(int goal, out float percentageCleared)
    {
        float actualGridLength = grid.Length - numOfWalls;
        float actualCapturedCount = captured.Count - numOfWalls;
        percentageCleared = (actualCapturedCount / actualGridLength) * 100;
        if (percentageCleared >= goal)
        {
            return true;
        }

        return false;
    }
    

    public Board(string spriteName) : base(spriteName)
    {
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        foreach (var square in touched)
        {
            spriteBatch.Draw(
                texture, 
                new Rectangle((int)(square.Y * singleSquareWidth), (int)(square.X * singleSquareHeight), (int)singleSquareWidth, (int)singleSquareHeight),
                capturedBackground[(int)square.X, (int)square.Y],
                Color.Black,
                MathHelper.ToRadians(tm.rotation),
                Vector2.Zero,
                effects,
                0
            );
        }
        
        foreach (var square in captured)
        {
            spriteBatch.Draw(
                texture, 
                new Rectangle((int)(square.Y * singleSquareWidth), (int)(square.X * singleSquareHeight), (int)singleSquareWidth, (int)singleSquareHeight),
                capturedBackground[(int)square.X, (int)square.Y],
                color,
                MathHelper.ToRadians(tm.rotation),
                Vector2.Zero,
                effects,
                0
            );
        }
    }
}