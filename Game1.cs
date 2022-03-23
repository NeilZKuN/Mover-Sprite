using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KeyBoard_Manager_Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _position;
        private KeyBoardManager km;
        Texture2D t2d;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            km = new KeyBoardManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _position = new Vector2(0, 0);
            t2d = Content.Load<Texture2D>("hqdefault");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _position.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _position.X -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _position.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _position.X += 1;
            }

            // TODO: Add your update logic here
            km.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(t2d, _position, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
