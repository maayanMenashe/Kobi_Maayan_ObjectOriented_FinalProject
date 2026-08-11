using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Maayan_Kobi;

public class Player : Entity
{
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
    //
    private float deltaTime;

    public bool canMove = true;

    public Player() : base("temp-player")
    {
        GameplayManager.player = this;
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

        destRect.Width /= 3;
        destRect.Height /= 3;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (canMove)
        {
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

            destRect.X = (int)tm.position.X;
            destRect.Y = (int)tm.position.Y;
        }
        

        

        if (Utils.IsOutOfBounds(tm.position, this))
        {
            tm.position =  prevPosition;
            isOutOfBounds = false;
        }
        prevPosition =  tm.position;
        
        
        currentSquareStatus = Utils.WhatSquareAmI(tm.position, out currentSquareX, out currentSquareY);

        if (currentSquareStatus == Board.Status.Uncaptured)
        {
            Board.grid[currentSquareX, currentSquareY] = Board.Status.Touched;
            Board.touched.Add(new Vector2(currentSquareX, currentSquareY));
        }

        if (currentSquareStatus == Board.Status.Captured && currentSquareStatus != prevSquareStatus)
        {
            AudioManager.PlaySoundEffect(AudioManager.capturedSXF);
            playerReachedSafety?.Invoke();
        }

        prevSquareStatus = currentSquareStatus;
    }
}