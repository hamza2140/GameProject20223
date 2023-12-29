using GameProject20223.Classes.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Data.Common;

namespace GameProject20223
{
    public class Game1 : Game
    {
        //variablen gegenereert door Monogame
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //variablen van mij voor de gamestate
        private GameState CurrentGameState;
        private GameState NextGameState;
        public void ChangeState(GameState newState)
        {
            NextGameState = newState;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1400;
            _graphics.PreferredBackBufferHeight = 787;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Updating the current gamestate
            if (NextGameState != null)
            {
                CurrentGameState = NextGameState;
                NextGameState = null;
            }

            CurrentGameState.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //clear
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            // Teken huidige game state
            CurrentGameState.Draw(gameTime, _spriteBatch);

            // End
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}