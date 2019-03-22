using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Components;

namespace Platformer.Sprites
{
    public class Sprite
    {
        Texture2D tex;
        
        public Vector2 pos, spriteSize;
        public bool isVisible;
        public Animation anim;
        public Sprite(Texture2D _tex, Vector2 _pos, Vector2 _spriteSize)
        {
            tex = _tex;
            pos = _pos;
            spriteSize = _spriteSize;
            isVisible = true;
        }

        public virtual void Update(GameTime gt, List<Sprite> _sprites)
        {

            anim.Update(gt, this.pos);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            anim.Draw(sb);
        }
    }
}
