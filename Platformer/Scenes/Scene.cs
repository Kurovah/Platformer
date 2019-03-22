using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Scenes
{
    public abstract class Scene
    {
        protected Game1 game;
        protected ContentManager content;
        protected Scene(Game1 _game, ContentManager _content)
        {
            game = _game;
            content = _content;
        }

        public abstract void Load();
        public abstract void Update(GameTime _gt);
        public abstract void Draw(SpriteBatch _sb, GameTime _gt);

    }
}
