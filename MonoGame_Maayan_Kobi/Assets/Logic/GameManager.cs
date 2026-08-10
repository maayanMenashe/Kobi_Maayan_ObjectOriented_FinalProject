using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame_Maayan_Kobi.Assets.UIX;

namespace MonoGame_Maayan_Kobi;

public class GameManager : IUpdatable
{
    public static HashSet<Enemy> allEnemies = new();
    public static Player player;

    private  int playerBaseLives = 3;
    private static int currentPlayerLives;

    private LevelManager levelManager;
    
    public static Action playerDied;


    public GameManager()
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
        AudioManager.PlaySoundEffect("Boom");
        playerDied?.Invoke();
        player.tm.position = player.spawnPoint;
        
        currentPlayerLives--;
        UIMain.RemainingLives(currentPlayerLives);
        if (currentPlayerLives == 0)
        {
            // game over
        }
    }

    private static void OnPlayerReachedSafety()
    {
        int requiredPrecent = LevelManager.currentLevel.goalPercent;
        if (Board.IsGoalPercentageReached(requiredPrecent, out float currentPrecent))
        {
            LevelManager.NextLevel();
        }
        UIMain.ClaimedPercentage((int)currentPrecent, requiredPrecent);
    }

    public void OnNextLevel()
    {
        player.tm.position = new Vector2(player.spawnPoint.X, player.spawnPoint.Y);
        currentPlayerLives = playerBaseLives;

        foreach (var enemy in allEnemies)
        {
            enemy.tm.position = enemy.spawnPoint;
        }
    }
}