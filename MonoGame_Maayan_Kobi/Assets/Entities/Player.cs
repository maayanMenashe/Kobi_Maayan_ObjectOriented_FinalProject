using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Maayan_Kobi;

public class Player : Entity
{
    int lives;
    //public Collider collider { get; }

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
    public static Action playerDied;
    //
    private Vector2 spawnPoint;
    private float deltaTime;


    public Player() : base("temp-player")
    {
        GameManager.player = this;
        speedMovement = 300;
        //collider = SceneManager.Create<Collider>();
        //collider.Parent = this;
        playerReachedSafety += Board.OnPlayerReachedSafety;
    }

    public override void Start()
    {
        base.Start();
        spawnPoint = new Vector2(texture.Width, texture.Height) / 4f;
        tm.position = spawnPoint;
        tm.scale = new Vector2(0.3f, 0.3f);
        
        prevPosition =  tm.position;
   }

    public override void Update(GameTime gameTime)
    {
        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //float deltaTime = (float)deltaTime;
        
        
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

        

        if (Utils.IsOutOfBounds(tm.position, this))
        {
            tm.position =  prevPosition;
            isOutOfBounds = false;
        }
        prevPosition =  tm.position;
        
        
        currentSquareStatus = Utils.WhatSquareAmI(tm.position, out currentSquareX, out currentSquareY);
        
        if (currentSquareStatus == Board.Status.Uncaptured)
            Board.grid[currentSquareX, currentSquareY] = Board.Status.Touched; // paint it black by the rolling stones

        if (currentSquareStatus == Board.Status.Captured && currentSquareStatus != prevSquareStatus)
            playerReachedSafety?.Invoke();

        prevSquareStatus = currentSquareStatus;
    }

    public void KillPlayer()
    {
        tm.position = spawnPoint;
        playerDied?.Invoke();
    }

    // public void OnCollision(Collider selfCollder, Collider otherCollder)
    // {
    //     isOutOfBounds = true;
    //     Console.WriteLine("Self " + selfCollder.Parent + " is colliding with " + otherCollder.Parent);
    // }
    //
    // public void OnTrigger(Collider selfCollder, Collider otherCollder)
    // {
    //     
    //     AudioManager.PlaySoundEffect("collect");
    //     
    //     Console.WriteLine("Self " + selfCollder.Parent + " is trigger with " + otherCollder.Parent);
    //     
    //     SceneManager.Remove(otherCollder);
    //     SceneManager.Remove(otherCollder.Parent);
    // }
}