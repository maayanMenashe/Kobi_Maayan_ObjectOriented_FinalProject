using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Maayan_Kobi;

public class GameplayManager : IUpdatable
{
    public static HashSet<Enemy> allEnemies = new();
    public static Player player;

    private  int playerBaseLives = 3;
    private static int currentPlayerLives = 3;
    
    public static int PlayerLives => currentPlayerLives;
    public static float PrecentCleared => boardPrecentCleared;

    private static float boardPrecentCleared;

    private LevelManager levelManager;
    
    public static Action playerDied;

    

    public GameplayManager()
    {
        levelManager = SceneManager.Create<LevelManager>();
        LevelManager.movedToNextLevel += OnNextLevel;
    }

    public void Start()
    {
        currentPlayerLives = playerBaseLives;
        Player.playerReachedSafety += OnPlayerReachedSafety;
        OnPlayerReachedSafety();
    }

    public void Update(GameTime gameTime)
    {
        if (!GameStateManager.IsPaused())
        {
            if (player != null && allEnemies.Count > 0)
            {
                foreach (var enemy in allEnemies)
                {
                    if (player.destRect.Intersects(enemy.destRect))
                    {
                        PlayPlayerDeathSequence();
                    }
                }
            }
        }
        else
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) )
            {
                GameStateManager.SetState(GameStateManager.GameState.Gameplay);
            }
        }
    }

    public static void PlayPlayerDeathSequence()
    {
        AudioManager.PlaySoundEffect(AudioManager.playerDeathSXF);
        playerDied?.Invoke();
        player.tm.position = player.spawnPoint;
        
        currentPlayerLives--;
        UIManager.RemainingLives(currentPlayerLives);
        if (currentPlayerLives == 0)
        {
            GameStateManager.SetState(GameStateManager.GameState.GameOver);
            LevelManager.ResetGame();
        }
    }

    private static void OnPlayerReachedSafety()
    {
        int requiredPrecent = LevelManager.currentLevel.goalPercent;
        if (Board.IsGoalPercentageReached(requiredPrecent, out boardPrecentCleared))
        {
            LevelManager.NextLevel();
        }
        UIManager.ClaimedPercentage((int)boardPrecentCleared, requiredPrecent);
    }

    public void OnNextLevel()
    {
        if (GameStateManager.CurrentState != GameStateManager.GameState.GameOver && GameStateManager.CurrentState != GameStateManager.GameState.YouWin)
        {
            GameStateManager.SetState(GameStateManager.GameState.Victory);
        }
        player.tm.position = player.spawnPoint;
        currentPlayerLives = playerBaseLives;
        foreach (var enemy in allEnemies)
        {
            enemy.tm.position = enemy.spawnPoint;
        }
    }
}