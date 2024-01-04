using GameProject20223.Classes.GameStates;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Button
{
    internal class RestartButton : MainButton
    {
        public RestartButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y) : base(game, graphicsDevice, content, X, Y)
        {
            _texture = content.Load<Texture2D>("restart");
        }

        internal override void DoBtnFunction()
        {
            _game.ChangeState(new InGame(_game, _graphicsDevice, _content));
        }
    }
}
