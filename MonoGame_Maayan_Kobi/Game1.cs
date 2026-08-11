using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MonoGame_Maayan_Kobi;

public class Game1 : Game
{
    //
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    //
    public static Vector2 _screenCenter;
    //
    private Player player = null;
    private Qix enemy = null;
    private Board board = null;
    private GameplayManager _gameplayManager = null;
    Texture2D texture;
    //
    public static SpriteFont _fontOswald;
    UIManager ui = new UIManager();
    //
    public const int ScreenWidth = 1920;
    public const int ScreenHeight = 1080;
    
    // public const int ScreenWidth = 1904;
    // public const int ScreenHeight = 1071;

    #region ResourcesManager   
    private ResourcesManager<Texture2D> textureManager;
    private ResourcesManager<Song> songManager;
    private ResourcesManager<SoundEffect> soundEffectManager;
    #endregion
    
    
    private SpriteManager spriteManager = null;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.IsFullScreen = true;

        textureManager = new(Content);
        songManager = new(Content);
        soundEffectManager = new(Content);
        spriteManager = new SpriteManager();
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        _graphics.IsFullScreen = false;
        
        _screenCenter =  new Vector2(
            _graphics.PreferredBackBufferWidth * 0.5f,
            _graphics.PreferredBackBufferHeight * 0.5f);

    }

    protected override void Initialize()
    {
        base.Initialize();
        
    }

    protected override void LoadContent()
    {
        _fontOswald = Content.Load<SpriteFont>("Fonts/Oswald");
        ui.wantedFont = _fontOswald;
        #region AudioManager init
        AudioManager.AddSong("theme", "Audio/OST/musinova_OSTMain");
        AudioManager.AddSoundEffect("Acquired", "Audio/SFX/Acquired");
        AudioManager.AddSoundEffect("Boom", "Audio/SFX/atari_boom4");
        #endregion

        _spriteBatch = new SpriteBatch(GraphicsDevice);

        #region SpriteManager init
        SpriteManager.AddSprite("Pixel", "Sprites/pixel");
        SpriteManager.AddSprite("temp-player", "Sprites/PH_Player");
        SpriteManager.AddSprite("DVDie", "Sprites/DVDIE");
        SpriteManager.AddSprite("captured-area", "Sprites/screen_qix_screen_paint");
        SpriteManager.AddSprite("Tutorial", "Sprites/TutorialBackground");
        SpriteManager.AddSprite("Victory", "Sprites/Victory_Background");
        SpriteManager.AddSprite("GameOver", "Sprites/GameOver_Background");
        #endregion
        texture = Content.Load<Texture2D>("Sprites/screen_qix_screen");
        Start();
    }

    void Start() //Yakir's Save
    {
        _gameplayManager = SceneManager.Create<GameplayManager>();
        //board = SceneManager.Create<Board>();
        AudioManager.PlaySong("theme");
        
        enemy = SceneManager.Create<Qix>();
        //enemy.PlayAnimation();
        
        player = SceneManager.Create<Player>();
        //player.PlayAnimation();
        

        ui.Start();
        
        SceneManager.Instance.Start();

        //player.collider.RegisterOnCollision(player.OnCollision);
        //player.collider.RegisterOnTrigger(player.OnTrigger);

    }

    bool ShouldExitApplication()
    {
        return GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
               Keyboard.GetState().IsKeyDown(Keys.Escape);
    }

    protected override void Update(GameTime gameTime)
    {
        if (ShouldExitApplication()) Exit();
        SceneManager.Instance.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkRed);

        _spriteBatch.Begin();
        _spriteBatch.Draw(texture, new Vector2(0,0), Color.White); //Background
        SceneManager.Instance.Draw(_spriteBatch);
        ui.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}