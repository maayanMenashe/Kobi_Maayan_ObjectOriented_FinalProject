using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public static class DFS
{
    public static void MarkAllEnemySquares(Vector2 pos)
    {
        Board.grid[(int)pos.X, (int)pos.Y] = Board.Status.Enemy;
        
        Stack<Vector2> toCheck = new Stack<Vector2>();
        AddNeighbours(pos, toCheck);
        
        while (toCheck.Count > 0)
        {
            Vector2 neighbour = toCheck.Pop();
            int xPos = (int)neighbour.X;
            int yPos = (int)neighbour.Y;
            if (Board.grid[xPos,yPos] == Board.Status.Uncaptured)
            {
                Board.grid[xPos, yPos] = Board.Status.Enemy;
                AddNeighbours(neighbour, toCheck);
            }
        }
        
    }

    private static void AddNeighbours(Vector2 pos, Stack<Vector2> neighbours)
    {
        int stepRange = 1;
        int stepRangeNega = -stepRange;
        
        for (int i = stepRangeNega; i <= stepRange; i++)
        {
            for (int j = stepRangeNega; j <= stepRange; j++)
            {
                if (Math.Abs(i) == Math.Abs(j))
                {
                    continue;
                }
                
                if (IsNeighbourInBorder( pos, i, j, out Vector2 newNeighbour))
                {
                    neighbours.Push(newNeighbour);
                }
            }

        }
    }
    
    private static bool IsNeighbourInBorder(Vector2 pos, int rowStep, int columnStep, out Vector2 neighbourPos)
    {
        float rowToCheck = pos.Y + rowStep;
        float columnToCheck = pos.X + columnStep;

        int rowBorder = Board.numOfRows;
        int columnBorder = Board.numOfColumns;

        if (rowToCheck >= 0 && rowToCheck < rowBorder && columnToCheck >= 0 && columnToCheck < columnBorder)
        {
            neighbourPos = new Vector2(columnToCheck, rowToCheck);
            return true;
        }
        neighbourPos = new Vector2();
        return false;
    }
}