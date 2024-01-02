using GameProject20223.Classes.Character;
using GameProject20223.Classes.Collectable;
using GameProject20223.Classes.Levelsdesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Background = GameProject20223.Classes.Levelsdesign.Background;

namespace GameProject20223.Classes.Levels
{
    public abstract class Level
    {
        public Map map;
        public List<Star> stars;
        public int MaxScore
        {
            get { return enemies.Count + stars.Count; }
        }

        internal Background background;
        internal Texture2D _backgroundTexture, _dragonTexture, _zombieTexture, _trapTexture;
        internal List<Enemy> enemies;
        internal ContentManager _content;
        internal GraphicsDevice _graphicsDevice;

        public Level(GraphicsDevice graphicsDevice, ContentManager content)
        {
            // Initialisatie
            _content = content;
            _graphicsDevice = graphicsDevice;

            enemies = new List<Enemy>();
            stars = new List<Star>();

            // Textures inladen
            _dragonTexture = _content.Load<Texture2D>("enemy");
            _zombieTexture = _content.Load<Texture2D>("zombie");
            _trapTexture = _content.Load<Texture2D>("skull");
            _backgroundTexture = _content.Load<Texture2D>("background");

            // Level genereren
            GenerateLevel();
        }
        public abstract void GenerateLevel();
    }

}
