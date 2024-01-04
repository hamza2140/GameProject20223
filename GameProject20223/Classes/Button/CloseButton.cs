﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject20223.Classes.Button
{
    internal class CloseButton : MainButton
    {
        public CloseButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y) : base(game, graphicsDevice, content, X, Y)
        {
            _texture = content.Load<Texture2D>("quit");
        }

        internal override void DoBtnFunction()
        {
            Application.Exit();
        }
    }
}
