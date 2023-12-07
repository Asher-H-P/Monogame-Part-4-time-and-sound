using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Part_4_time_and_sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombTexture;
        Texture2D explosionTexture;
        private SpriteFont timer;
        Rectangle bombRect;
        SoundEffect explode;
        SoundEffect b17;
        float seconds;
        float startTime;
        MouseState mouseState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "bomb";
            bombRect = new Rectangle(50, 50, 700, 400);
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bombTexture = Content.Load<Texture2D>("bomb");
            timer = Content.Load<SpriteFont>("Writing");
            explode = Content.Load<SoundEffect>("explosion");
            b17 = Content.Load<SoundEffect>("B-17 mattel presents");
            explosionTexture = Content.Load<Texture2D>("explosionpic");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }
            mouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.GreenYellow);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(timer, seconds.ToString("00.0"), new Vector2(250, 200), Color.Crimson);
            if (seconds >= 15)
            {
                b17.Play();
                explode.Play();
                explode.Equals(true);
                startTime = (float)gameTime.TotalGameTime.TotalSeconds + 10;
            }
            if (seconds <= 0)
            {
                _spriteBatch.Draw(explosionTexture, new Vector2(0, 0), Color.White);
            }
            _spriteBatch.End();
            if (seconds <= -1 && seconds > -2)
            {
                Exit();
            }
                base.Draw(gameTime);
        }
    }
}