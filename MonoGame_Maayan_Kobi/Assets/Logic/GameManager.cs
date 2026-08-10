using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class GameManager : IUpdatable
{
    public static HashSet<Enemy> allEnemies = new();
    public static Player player;

    private static int playerLives = 3;
    
    public static Action playerDied;


    public void Start()
    {
        
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
        
        playerLives--;
        if (playerLives == 0)
        {
            // game over
        }
    }

    // private static void OnPlayerReachedSafety()
    // {
    //     if (Board.IsGoalPercentageReached(goal))
    //     {
    //         clear
    //     }
    //     
    // }
}