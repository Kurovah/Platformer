using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Components;

namespace Platformer.Sprites
{
    class Solid:Sprite
    {
        public Vector2 velocity,push;
        public Solid(Texture2D _tex, Vector2 _pos, Vector2 _spriteSize)
            : base(_tex, _pos, _spriteSize)
        {
            anim = new Animation(_tex, _pos, new Vector2(32, 32), new Vector2(32,32), _spriteSize, 0);
        }
        public override void Update(GameTime gt, List<Sprite> _sprites)
        {
            if(push.X > 0) { push.X -= 0.1f; }
            if (push.Y > 0) { push.Y -= 0.1f; }
            pos += new Vector2(velocity.X+push.X, velocity.Y + push.Y);
            base.Update(gt, _sprites);
        }

        #region collision
        protected bool checkBottom(Sprite s)
        {
            return anim.desRect.Top + velocity.Y < s.anim.desRect.Bottom &&
                anim.desRect.Bottom > s.anim.desRect.Bottom &&
                anim.desRect.Right > s.anim.desRect.Left &&
                anim.desRect.Left < s.anim.desRect.Right;
        }

        protected bool checkTop(Sprite s)
        {
            return anim.desRect.Bottom + velocity.Y > s.anim.desRect.Top &&
                anim.desRect.Top < s.anim.desRect.Top &&
                anim.desRect.Right > s.anim.desRect.Left &&
                anim.desRect.Left < s.anim.desRect.Right;
        }

        protected bool checkLeft(Sprite s)
        {
            return anim.desRect.Top < s.anim.desRect.Bottom &&
                anim.desRect.Bottom > s.anim.desRect.Top &&
                anim.desRect.Left < s.anim.desRect.Left &&
                anim.desRect.Right + velocity.X > s.anim.desRect.Left;
        }

        protected bool checkRight(Sprite s)
        {
            return anim.desRect.Top < s.anim.desRect.Bottom &&
                anim.desRect.Bottom > s.anim.desRect.Top &&
                anim.desRect.Left + velocity.X < s.anim.desRect.Right &&
                anim.desRect.Right > s.anim.desRect.Right;
        }
        #endregion
    }
}
