﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject20223.Classes.Button;

namespace GameProject20223.Classes.GameStates
{
    // Bron Gamestates
    // Oyyou. (z.d.). MonoGame Tutorials 13. GitHub. https://github.com/Oyyou/MonoGame_Tutorials/tree/master/MonoGame_Tutorials/Tutorial013
    public abstract class GameState
    {
        protected Game _game;
        protected GraphicsDevice _graphicsDevice;
        protected ContentManager _content;

        internal List<cButton> buttons;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;

            buttons = new List<cButton>();
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
