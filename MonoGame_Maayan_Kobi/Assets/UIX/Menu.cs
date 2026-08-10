using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace MonoGame_Maayan_Kobi
{
    public class Menu: IDrawable
    {
        public delegate void Started();
        public Texture2D sharedTexture; 
        public SpriteFont sharedFont; // All buttons have shared resources
        public Game gameOneLogic;
        public bool interactable = true;
        public event Started started;
        //
        public Button startButton = new Button();
        public Button quitButton = new Button();
        //
        public void MenuStart()
        {
            started.Invoke();
        }
        public void MenuSettings()
        {
            Debug.WriteLine("Oh noooo where are the settings?? D:");
        }
        public void MenuQuit()
        {
            gameOneLogic.Exit();
        }
        public void Start(Game wantedGame)
        {
            gameOneLogic = wantedGame; // This allows menu to quit the game
            //Subscribing to events
            startButton.ClickAction += MenuStart;
            quitButton.ClickAction += MenuQuit;
            //Textures
            startButton.texture = sharedTexture;
            quitButton.texture = sharedTexture;
            //Fonts
            startButton.content.font = sharedFont;
            quitButton.content.font = sharedFont;
            //Text
            startButton.content.text = "Start";
            quitButton.content.text = "Quit";
        }
        public void Update(GameTime gameTime)
        {
            if (!interactable) return;
            startButton.Update(gameTime);
            quitButton.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!interactable) return;
            startButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);
        }
    }
}
