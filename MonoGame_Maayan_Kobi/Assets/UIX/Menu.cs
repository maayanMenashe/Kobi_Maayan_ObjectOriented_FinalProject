using System.Resources;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Maayan_Kobi;

public static class Menu
{
    // texts
    private static string tutorialText = "Use WASD or arrow keys to move\r\nClaim as much territory as required to advance\r\nto the next level\r\nAvoid the notorious LogoBounce or lose a life\r\n\r\n--PRESS ENTER TO START THE DIGITAL LIBERATION--";
    private static string victoryText;
    private static string gameOverText;

    
    // texture names
    private static string tutorialBGName = "Tutorial";
    private static string victoryBGName = "Victory";
    private static string gameOverBGName = "GameOver";
    
    // textures
    private static Texture2D tutorialBG = ResourcesManager<Texture2D>.GetResource(tutorialBGName);
    private static Texture2D victoryBG = ResourcesManager<Texture2D>.GetResource(victoryBGName);
    private static Texture2D gameOverBG = ResourcesManager<Texture2D>.GetResource(gameOverBGName);

    // font
    public static SpriteFont font = Game1._fontOswald;

    

    public static Texture2D GetBackgroundAndTextTutorial(out Text screenText)
    {
        screenText = new Text();
        screenText.font = font;
        screenText.text = tutorialText;
        screenText.tm.position = Game1._screenCenter;
        return tutorialBG;
    }
    
    public static Texture2D GetBackgroundAndTextVictory(int lives, int cleared, out Text screenText)
    {
        victoryText = $"LEVEL CLEARED!!!\r\nYou cleared {cleared}% of the board, good job!\r\n\r\nYou have {lives} lives left\r\n--PRESS ENTER TO CONTINUE THE DIGITAL LIBERATION--";
        screenText = new Text();
        screenText.font = font;
        screenText.text = victoryText;
        screenText.tm.position = Game1._screenCenter;
        return victoryBG;
    }
    
    public static Texture2D GetBackgroundAndTextGameOver(int level, out Text screenText)
    {
        gameOverText = $"GAME_OVER\r\nY O U D I E D A T L E V E L {level}\r\nY O U W I L L N E V E R B E L I B E R A T E D . . .\r\n\r\n\r\n\r\nUnless you press start and try again (:";
        screenText = new Text();
        screenText.font = font;
        screenText.text = gameOverText;
        screenText.tm.position = Game1._screenCenter;
        return gameOverBG;
    }
    
}