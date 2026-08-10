using System;
using System.Transactions;
using Microsoft.Xna.Framework;

namespace MonoGame_Maayan_Kobi;

public class Enemy : Entity
{
    public Vector2 velocity = new Vector2(1,1);
    
    //public Collider collider { get; }
    
    public Enemy(string spriteName) : base(spriteName)
    {
        GameManager.allEnemies.Add(this);
        // collider = SceneManager.Create<Collider>();
        // collider.Parent = this;
        // collider.IsTrigger = true;
        Player.playerReachedSafety += OnPlayerReachedSafety;
    }
    
    public override void Start()
    {
        base.Start();
        
        tm.position.Y -= 300;
        tm.scale = new Vector2(0.3f, 0.3f);
    }

    private void OnPlayerReachedSafety()
    {
        DFS.MarkAllEnemySquares(Utils.CheckCurrentSquare(tm.position));
    }
}