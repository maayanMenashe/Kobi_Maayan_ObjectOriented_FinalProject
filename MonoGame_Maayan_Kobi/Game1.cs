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
    //
    private SpriteFont _fontOswald;
    //
    MousePositionText mousePositionText = new MousePositionText();
    //
    public const int ScreenWidth = 1920;
    public const int ScreenHeight = 1080;

    #region ResourcesManager   
    private ResourcesManager<Texture2D> textureManager;
    private ResourcesManager<Song> songManager;
    private ResourcesManager<SoundEffect> soundEffectManager;
    #endregion
    
    
    private SpriteManager spriteManager = null;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

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
        #region AudioManager init
        //AudioManager.AddSong("theme", "Audio/Music/theme");
        //AudioManager.AddSoundEffect("bounce", "Audio/SFX/bounce");
        #endregion


        _spriteBatch = new SpriteBatch(GraphicsDevice);

        #region SpriteManager init
        SpriteManager.AddSprite("Pixel", "Sprites/pixel");
        SpriteManager.AddSprite("temp-background", "Sprites/PH_Background");
        SpriteManager.AddSprite("temp-border", "Sprites/PH_Border");
        SpriteManager.AddSprite("temp-player", "Sprites/PH_Player");
        SpriteManager.AddSprite("captured-area", "Sprites/Result_TestCard");
        #endregion

        mousePositionText.font = Content.Load<SpriteFont>("Fonts/Oswald");
        
        Start();
    }

    void Start()
    {
        board = SceneManager.Create<Board>();
        //AudioManager.PlaySong("theme");
        
        enemy = SceneManager.Create<Qix>();
        //enemy.PlayAnimation();
        
        player = SceneManager.Create<Player>();
        player.PlayAnimation();
        

        
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

        SceneManager.Instance.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}