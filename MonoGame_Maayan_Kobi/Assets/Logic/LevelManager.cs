using System;
using System.Collections.Generic;

namespace MonoGame_Maayan_Kobi;

public class LevelManager
{
    public static Board currentBoard;
    public static LevelParams currentLevel;
    private static List<LevelParams> levels;

    private static int levelNum = 1;

    public static Action movedToNextLevel;


    public struct LevelParams(int levelNum, int goalPercent)
    {
        public int levelNum = levelNum;
        public int goalPercent = goalPercent;
    }


    public LevelManager()
    {
        currentBoard = SceneManager.Create<Board>();
        InitLevelsList();
        currentLevel = levels[0];
    }


    private void InitLevelsList()
    {
        levels = new List<LevelParams>();
        
        // level 1
        LevelParams level1 = new LevelParams(1, 80);
        levels.Add(level1);
        
        // level 2
        LevelParams level2 = new LevelParams(2, 82);
        levels.Add(level2);
        
        // level 3
        LevelParams level3 = new LevelParams(3, 1);
        levels.Add(level3);
        
        // level 4
        LevelParams level4 = new LevelParams(4, 88);
        levels.Add(level4);
        
        // level 5
        LevelParams level5 = new LevelParams(5, 90);
        levels.Add(level5);
    }

    public static void NextLevel()
    {
        if (levels.Count == levelNum)
        {
            GameStateManager.SetState(GameStateManager.GameState.YouWin);
            ResetGame();
            return;
        }
        currentLevel = levels[levelNum];
        levelNum++;
        currentBoard.ResetBoard();
        UIManager.CurrentLevel(levelNum);
        UIManager.ClaimedPercentage(0, currentLevel.goalPercent);
        movedToNextLevel?.Invoke();
    }

    public static void ResetGame()
    {
        levelNum = 0;
        NextLevel();
    }
}