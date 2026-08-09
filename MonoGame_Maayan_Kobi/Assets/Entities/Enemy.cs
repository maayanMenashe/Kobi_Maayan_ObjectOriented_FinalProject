using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class Enemy : Animation
{
    public Collider collider { get; }
    //test
    
    public Enemy() : base("egret")
    {
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        collider.IsTrigger = true;
    }
    
    public override void Start()
    {
        base.Start();
        
        tm.position = Game1._screenCenter;
        tm.position.Y -= 300;
        tm.scale = new Vector2(0.3f, 0.3f);
    }
    void MovementLogic()
    {

    }
}