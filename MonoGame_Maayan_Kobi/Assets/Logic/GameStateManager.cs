using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Maayan_Kobi;

public class GameStateManager : IDrawable
{
    public enum GameState
    {
        MainMenu,
        Gameplay,
        Victory,
        GameOver
    }
    public GameState CurrentState { get; private set; } = GameState.MainMenu;

    public bool IsPaused()
    {
        if (CurrentState == GameState.Gameplay)
        {
            return false;
        }
        return true;
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        Text screenText = null;
        Texture2D BG = null;

        switch (CurrentState)
        {
            case GameState.MainMenu:
                BG = Menu.GetBackgroundAndTextTutorial(out screenText);
                break;

            case GameState.Gameplay:
                UIManager.lives.Draw(spriteBatch);
                UIManager.claimed.Draw(spriteBatch);
                UIManager.currentLevel.Draw(spriteBatch);
                return;
            
            case GameState.Victory:
                BG = Menu.GetBackgroundAndTextVictory(GameplayManager.PlayerLives, (int)GameplayManager.PrecentCleared, out screenText);
                break;

            case GameState.GameOver:
                BG = Menu.GetBackgroundAndTextGameOver(LevelManager.currentLevel.levelNum, out screenText);
                break;
        }

        if (BG != null && screenText != null)
        {
            spriteBatch.Draw(BG,Vector2.Zero, Color.White);
            screenText.Draw(spriteBatch);
        }
    }
}