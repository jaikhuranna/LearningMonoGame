using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D targetSprite;
    private Texture2D crosshairsSprite;
    private Texture2D backroundSprite;
    private SpriteFont gameFont;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here
        targetSprite = Content.Load<Texture2D>("target");
        crosshairsSprite = Content.Load<Texture2D>("crosshairs");
        backroundSprite = Content.Load<Texture2D>("sky");
        gameFont = Content.Load<SpriteFont>("galleryFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(backroundSprite, new Vector2(0,0), Color.White);
        _spriteBatch.DrawString(gameFont, "Test Message", new Vector2(100, 100), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
