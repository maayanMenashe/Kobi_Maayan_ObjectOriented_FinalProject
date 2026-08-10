using System.Transactions;
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class Enemy : Animation
{
    public Collider collider { get; }
    
    public Enemy() : base("temp-player")
    {
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        collider.IsTrigger = true;
        Player.playerReachedSafety += OnPlayerReachedSafety;
    }
    
    public override void Start()
    {
        base.Start();
        
        tm.position = Game1._screenCenter;
        tm.position.Y -= 300;
        tm.scale = new Vector2(0.3f, 0.3f);
    }
    public virtual void Update(GameTime gameTime)
    {
        Action(gameTime);
    }
    protected virtual void Action(GameTime gameTime) //The action function
    {
    }

    private void OnPlayerReachedSafety()
    {
        DFS.MarkAllEnemySquares(  Utils.CheckCurrentSquare(this));
    }
}