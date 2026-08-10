using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class GameManager : IUpdatable
{
    public static HashSet<Enemy> allEnemies = new();
    public static Player player;

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
                    player.KillPlayer();
                }
            }
        }
    }
}