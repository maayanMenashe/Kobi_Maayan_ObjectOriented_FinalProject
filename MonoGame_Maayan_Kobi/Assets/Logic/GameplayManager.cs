using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class GameplayManager : IUpdatable
{
    public static HashSet<Enemy> allEnemies = new();
    public static Player player;

    private  int playerBaseLives = 3;
    private static int currentPlayerLives;
    
    public static int PlayerLives => currentPlayerLives;
    public static float PrecentCleared => boardPrecentCleared;

    private static float boardPrecentCleared;

    private LevelManager levelManager;
    
    public static Action playerDied;

    

    public GameplayManager()
    {
        levelManager = SceneManager.Create<LevelManager>();
        levelManager.movedToNextLevel += OnNextLevel;
    }

    public void Start()
    {
        currentPlayerLives = playerBaseLives;
        Player.playerReachedSafety += OnPlayerReachedSafety;
        OnPlayerReachedSafety();
    }

    public void Update(GameTime gameTime)
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

    public static void PlayPlayerDeathSequence()
    {
        AudioManager.PlaySoundEffect(AudioManager.playerDeathSXF);
        playerDied?.Invoke();
        player.tm.position = player.spawnPoint;
        
        currentPlayerLives--;
        UIManager.RemainingLives(currentPlayerLives);
        if (currentPlayerLives == 0)
        {
            // game over
        }
    }

    private static void OnPlayerReachedSafety()
    {
        int requiredPrecent = LevelManager.currentLevel.goalPercent;
        if (Board.IsGoalPercentageReached(requiredPrecent, out boardPrecentCleared))
        {
            //player.canMove = false;
            LevelManager.NextLevel();
        }
        UIManager.ClaimedPercentage((int)boardPrecentCleared, requiredPrecent);
    }

    public void OnNextLevel()
    {
        player.tm.position = player.spawnPoint;
        currentPlayerLives = playerBaseLives;

        foreach (var enemy in allEnemies)
        {
            enemy.tm.position = enemy.spawnPoint;
        }
        // also reset the destrects
    }
}