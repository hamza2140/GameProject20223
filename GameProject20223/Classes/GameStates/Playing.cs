using GameProject20223.Character;
using GameProject20223.Classes.Levels;
using GameProject20223.Classes.Levelsdesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.GameStates
{
    internal class Playing : GameState
    {
        // Variabelen initialiseren
        new Game1 _game;
        private static int counter = 0;

        private Texture2D _heroTexture;

        private Hero hero;
        private KeyboardReader KBReader;
        internal Levels.Level level1, level2, currentLevel;

        public Playing(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Game inladen
            _game = game;
            _heroTexture = _content.Load<Texture2D>("sprite");


            KBReader = new KeyboardReader();
            hero = new Hero(_heroTexture, KBReader);

            Tiles.Content = _content;

            level1 = new Level1(graphicsDevice, _content);
            level2 = new Level2(graphicsDevice, _content);

            currentLevel = level1;
        }
        public override void Update(GameTime gameTime)
        {
            currentLevel.Update(gameTime);
            hero.Update(gameTime);
            foreach (CollisionTiles tile in currentLevel.map.CollisionTiles)
            {
                hero.Collision(tile.Rectangle, currentLevel.map.Width, currentLevel.map.Height);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentLevel.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }
    }
}
