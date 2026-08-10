using System.Collections.Generic;

namespace MonoGame_Maayan_Kobi;

public static class GameManager
{
    public static HashSet<Sprite> allEntities = new HashSet<Sprite>();


    public static void AddEntity(Sprite thisSprite)
    {
        allEntities.Add(thisSprite);
    }
}