using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

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
        //player.KillPlayer();
        AudioManager.PlaySoundEffect("Boom");
        playerDied?.Invoke();
        player.tm.position = player.spawnPoint;
        
        currentPlayerLives--;
        if (currentPlayerLives == 0)
        {
            // game over
        }
    }

    private static void OnPlayerReachedSafety()
    {
        if (Board.IsGoalPercentageReached(LevelManager.currentLevel.goalPercent))
        {
            LevelManager.NextLevel();
        }
    }

    public void OnNextLevel()
    {
        player.tm.position = player.spawnPoint;
        currentPlayerLives = playerBaseLives;

        foreach (var enemy in allEnemies)
        {
            enemy.tm.position = enemy.spawnPoint;
        }
    }
}