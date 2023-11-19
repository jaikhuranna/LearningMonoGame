using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    //Declarations
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D targetSprite;
    private Texture2D crosshairsSprite;
    private Texture2D backroundSprite;
    private SpriteFont gameFont;
    
    private Vector2 targetPosition = new Vector2(300, 300);
    private const int targetRadius = 45;
    private int score = 0;

    private bool mRelease = true;
    private int leway = 10; 
    
    private MouseState mState;
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
        mState = Mouse.GetState();
        
        switch (mState.LeftButton)
        {
            case ButtonState.Pressed when mRelease == true:
                float mouseTargetDistance = Vector2.Distance(targetPosition, mState.Position.ToVector2());
                if (mouseTargetDistance <= targetRadius + leway)
                { 
                    score++;
                    Random rand = new Random();

                    targetPosition.X = rand.Next(targetRadius , _graphics.PreferredBackBufferWidth - targetRadius);
                    targetPosition.Y = rand.Next(targetRadius , _graphics.PreferredBackBufferHeight - targetRadius);
                }
                mRelease = false;
                break;
            case ButtonState.Released:
                mRelease = true;
                break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(backroundSprite, new Vector2(0,0), Color.White);
        _spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(100, 100), Color.White);
        _spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X - targetRadius, targetPosition.Y - targetRadius), Color.White);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
