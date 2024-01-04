using GameProject20223.Classes.Button;
using GameProject20223.Classes.Levelsdesign;
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
    internal class MainMenu : GameState
    {
        new Game1 _game;

        private Texture2D _backgroundTexture;
        private Background background;

        public MainMenu(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            // Sleep zodat er niet tweemaal op een knop word gedrukt na game over
            Thread.Sleep(200);

            // Game inladen
            _game = game;

            // Textures inladen
            _backgroundTexture = _content.Load<Texture2D>("mainscreen");

            // Initialiseren
            background = new Background(_backgroundTexture);

            // Knoppen toevoegen
            buttons.Add(new StartButton(game, graphicsDevice, content, 610, 400));
            buttons.Add(new CloseButton(game, graphicsDevice, content, 610, 480));
        }
    }
}
