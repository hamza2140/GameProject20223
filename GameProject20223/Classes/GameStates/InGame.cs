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
using System.Threading;
using System.Threading.Tasks;

namespace GameProject20223.Classes.GameStates
{
    internal class InGame : GameState
    {
        // Variabelen initialiseren
        new Game1 _game;
        private static int counter = 0;

        private Texture2D _heroTexture;

        private Hero hero;
        private KeyboardReader KBReader;
        internal Levels.MainLevel level1, level2, currentLevel;

        public InGame(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Game inladen
            _game = game;
            _heroTexture = _content.Load<Texture2D>("sprite");


            KBReader = new KeyboardReader();
            hero = new Hero(_heroTexture, KBReader);

            Blocks.Content = _content;

            level1 = new LevelOne(graphicsDevice, _content);
            level2 = new LevelTwo(graphicsDevice, _content);

            currentLevel = level1;
        }
        public override void Update(GameTime gameTime)
        {
            currentLevel.Update(gameTime);
            hero.Update(gameTime);
            foreach (CollisionBlocks tile in currentLevel.map.CollisionTiles)
            {
                hero.Collision(tile.Rectangle, currentLevel.map.Width, currentLevel.map.Height);
            }
            foreach (var enemy in currentLevel.enemies)
            {
                // Hero zal de vijand doden door er langs bovenop te springen.
                if (hero.rectangle.TouchTopOf(enemy.rectangle))
                {
                    enemy.Die();
                    hero.EnemyDead(true);
                }

                // Als we een enemy de hero raakt -> hero sterft
                if (hero.rectangle.Intersects(enemy.rectangle))
                {
                    if (!KBReader.ReadAttack())
                    {
                        // Hero sterft 
                        Hero.score = 0;
                        counter = 0;
                        _game.ChangeState(new GameOver(_game, _graphicsDevice, _content));
                        Thread.Sleep(400);
                    }
                    else
                    {
                        enemy.Die();
                        hero.EnemyDead(false);
                    }
                }

                // Als we het level hebben gehaald
                if (Hero.score == currentLevel.MaxScore)
                {
                    counter++;
                    Hero.score = 0;
                    if (counter > 1)
                    {
                        _game.ChangeState(new WinnerState(_game, _graphicsDevice, _content));
                        counter = 0;
                    }
                    else
                    {
                        _game.ChangeState(new InGame(_game, _graphicsDevice, _content) { currentLevel = level2 });
                    }

                    Thread.Sleep(400);
                }
            }
            foreach (var star in currentLevel.ninjaStars)
            {
                if (hero.rectangle.Intersects(star.rectangle))
                {
                    star.Collected();
                }
            }
        }       

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentLevel.Draw(spriteBatch);
            hero.Draw(spriteBatch);
        }
    }
}
