using System;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Maayan_Kobi;

public class Enemy : Entity
{
    public Vector2 velocity = new Vector2(1,1);
    protected int spawningLevel = 0;
    protected float deltaTime;
    protected Vector2 prevPos = Game1._screenCenter;
    protected Vector2 nextPos;
    protected Board.Status currentSquareStatus;
    protected Board.Status forbiddenSquareStatus;
    
    public Enemy(string spriteName) : base(spriteName)
    {
        Player.playerReachedSafety += OnPlayerReachedSafety;
        destRect.Width /= 3;
        destRect.Height /= 3;
        GameplayManager.allEnemies.Add(this);
    }
    
    public override void Start()
    {
        base.Start();
        
        tm.position.Y -= 300;
        tm.scale = new Vector2(0.3f, 0.3f);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        tm.position += new Vector2(1f,1f) * velocity * deltaTime * speedMovement;
        currentSquareStatus = Utils.CurrentSquareStatus(tm.position, out int currentSquareX, out int currentSquareY);
        if (Utils.IsOutOfBounds(tm.position, this) || currentSquareStatus == forbiddenSquareStatus)
        {
            tm.position = prevPos;
            ChangeDirection();
        }
        prevPos = tm.position;
        destRect.X = (int)tm.position.X;
        destRect.Y = (int)tm.position.Y;


    }

    protected void OnPlayerReachedSafety()
    {
        DFS.MarkAllEnemySquares(Utils.CheckCurrentSquare(tm.position));
    }
    
    protected void ChangeDirection()
    {
        Vector2 nextStep =  tm.position + new Vector2(1f,1f) * velocity * deltaTime * speedMovement;
        Vector2 nextVerticalPos = new Vector2(nextStep.X, tm.position.Y);
        Vector2 nextHorizontalPos = new Vector2(tm.position.X, nextStep.Y);
        if (Utils.IsOutOfBounds(nextVerticalPos, this) || Utils.CurrentSquareStatus(nextVerticalPos, out int a, out int b) == Board.Status.Captured)
        {
            velocity *= new Vector2(-1, 1);
        }
            
        if (Utils.IsOutOfBounds(nextHorizontalPos, this) || Utils.CurrentSquareStatus(nextHorizontalPos, out int c, out int d) == Board.Status.Captured)
        {
            velocity *= new Vector2(1, -1);
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (LevelManager.currentLevel.levelNum > spawningLevel)
        {
            base.Draw(spriteBatch);
        }
    }
}