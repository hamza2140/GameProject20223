﻿using GameProject20223.Classes.Button;
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
    internal class GameOver : GameState
    {
        private Texture2D _backgroundTexture;
        private Background background;

        public GameOver(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Textures inladen
            _backgroundTexture = _content.Load<Texture2D>("gameover");

            // Initialiseren
            background = new Background(_backgroundTexture);

            buttons.Add(new MenuButton(game, graphicsDevice, content, 610, 400));
            buttons.Add(new RestartButton(game, graphicsDevice, content, 610, 480));
            buttons.Add(new CloseButton(game, graphicsDevice, content, 610, 560));
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Alle elementen tekenen
            background.Draw(spriteBatch);

            foreach (var button in buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Knoppen updaten
            foreach (var button in buttons)
            {
                button.Update(gameTime);
            }
        }
    }
}
