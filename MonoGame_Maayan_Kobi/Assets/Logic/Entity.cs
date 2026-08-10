namespace MonoGame_Maayan_Kobi;

public class Entity : Animation
{
    public Entity(string spriteName) : base(spriteName)
    {
        GameManager.allEntities.Add(this);
    }
}