using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Maayan_Kobi;

public class Player : Animation
{
    float speedMovement = 300;
    int lives;
    public Collider collider { get; }

    bool isOutOfBounds = false;
    Vector2 prevPosition = Vector2.Zero;
    
    //
    private int currentSquareX;
    private int currentSquareY;
    private Vector2 currentSquarePos;
    private Board.Status currentSquareStatus;
    private Board.Status prevSquareStatus = Board.Status.Captured;
    //
    public static Action playerReachedSafety;


    public Player() : base("temp-player")
    {
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        playerReachedSafety += Board.OnPlayerReachedSafety;
    }

    public override void Start()
    {
        base.Start();
        
        tm.position = Vector2.Zero;
        tm.scale = new Vector2(0.3f, 0.3f);
        
        prevPosition =  tm.position;
   }

    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        
        if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            effects = SpriteEffects.FlipHorizontally;
            tm.position += new Vector2(speedMovement * deltaTime, 0);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            effects = SpriteEffects.None;
            tm.position += new Vector2(-speedMovement * deltaTime, 0);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            tm.position += new Vector2(0, speedMovement * deltaTime);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            tm.position += new Vector2(0, -speedMovement * deltaTime);
        }
        
        //base.Update(gameTime);

        
        if (tm.position.X < 0 || tm.position.Y < 0 || tm.position.X > Game1.ScreenWidth - texture.Width/2f + 15|| tm.position.Y > Game1.ScreenHeight - texture.Height/2f - 10)
        {
            isOutOfBounds = true;
        }
        if (isOutOfBounds)
        {
            tm.position =  prevPosition;
            isOutOfBounds = false;
        }
        prevPosition =  tm.position;

        currentSquarePos = Utils.CheckCurrentSquare(this);
        currentSquareX = (int)currentSquarePos.X;
        currentSquareY = (int)currentSquarePos.Y;
        currentSquareStatus = Board.grid[currentSquareX, currentSquareY];

        if (currentSquareStatus == Board.Status.Uncaptured)
        {
            Board.grid[currentSquareX, currentSquareY] = Board.Status.Touched;
            // paint it black by the rolling stones
        }

        if (currentSquareStatus == Board.Status.Captured && currentSquareStatus != prevSquareStatus)
        {
            playerReachedSafety?.Invoke();
        }

        prevSquareStatus = currentSquareStatus;
    }

    public void OnCollision(Collider selfCollder, Collider otherCollder)
    {
        isOutOfBounds = true;
        Console.WriteLine("Self " + selfCollder.Parent + " is colliding with " + otherCollder.Parent);
    }
    
    public void OnTrigger(Collider selfCollder, Collider otherCollder)
    {
        
        AudioManager.PlaySoundEffect("collect");
        
        Console.WriteLine("Self " + selfCollder.Parent + " is trigger with " + otherCollder.Parent);
        
        SceneManager.Remove(otherCollder);
        SceneManager.Remove(otherCollder.Parent);
    }
}