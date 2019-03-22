using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Components;
using Platformer.Sprites;

namespace Platformer.Scenes
{
    public class testRoom2 : Scene
    {
        List<Sprite> sl;
        Player p;
        Cam c;
        public Vector2 playerPos;
        public testRoom2(Game1 _game, ContentManager _content, Vector2 _playerPos):base(_game, _content)
        {
            playerPos = _playerPos;
        }

        public override void Load()
        {
            sl = new List<Sprite>();
            
            sl.Add(new Solid(content.Load<Texture2D>("forP"), new Vector2(0), new Vector2(1200, 32)));
            sl.Add(new Solid(content.Load<Texture2D>("forP"), new Vector2(0), new Vector2(32, 480)));
            sl.Add(new Solid(content.Load<Texture2D>("forP"), new Vector2(1200, 0), new Vector2(32, 480)));
            sl.Add(new Solid(content.Load<Texture2D>("forP"), new Vector2(0, 480), new Vector2(1200, 32)));
            

            p = new Player(content.Load<Texture2D>("forP"), playerPos, new Vector2(32));
            sl.Add(p);
            sl.Add(new Door(content.Load<Texture2D>("forP"), new Vector2(200, 416),new Vector2(25, 64), new Vector2(60, 420), "TestRoom1", game));
            c = new Cam(p, new Vector2(400, 1200), new Vector2(240));
            c.currentPos = p.pos;
        }

        public override void Update(GameTime _gt)
        {
            foreach (Sprite s in sl)
            {
                s.Update(_gt, sl);
            }
            c.Update(_gt);
            for (int i = 0; i < sl.Count; i++)
            {
                if (sl[i].isVisible == false) { sl.RemoveAt(i); i--; }
            }
        }

        public override void Draw(SpriteBatch _sb, GameTime _gt)
        {
            _sb.Begin(transformMatrix: c.trans);
            foreach (Sprite s in sl)
            {
                s.Draw(_sb);
            }
            _sb.End();
        }
    }
}
