using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Scenes;
using Platformer.Components;

namespace Platformer.Sprites
{
    public class Door : Sprite
    {
        public Vector2 targetPos;
        public String targetScene;
        public Game1 g;
        public Door(Texture2D _tex, Vector2 _pos, Vector2 _spriteSize, Vector2 _tpos, String _ts, Game1 _g)
            : base(_tex, _pos, _spriteSize)
        {
            targetPos = _tpos;
            targetScene = _ts;
            g = _g;
            anim = new Animation(_tex, _pos, new Vector2(0), new Vector2(32), _spriteSize, 0);
        }

        public override void Update(GameTime gt, List<Sprite> _sprites)
        {
            foreach (Sprite p in _sprites)
            {
                if (p.anim.desRect.Intersects(this.anim.desRect) && p.GetType() == typeof(Player))//if door is touched go to the next room that is linked to this one
                {
                    switch (targetScene)
                    {
                        case "TestRoom1":
                            g.nextScene = new testRoom1(g, g.Content, targetPos);
                            break;
                        case "TestRoom2":
                            g.nextScene = new testRoom2(g, g.Content, targetPos);
                            break;
                    }
                }
            }
            base.Update(gt, _sprites);
        }
    }
}
