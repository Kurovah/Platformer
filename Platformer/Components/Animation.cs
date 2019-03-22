using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Components
{
    public class Animation
    {
        public int frames;
        public Rectangle sourceRect, desRect;
        public Vector2 pos, sPos, spriteSize, sourceSize;
        public Texture2D tex;
        public Animation(Texture2D _tex, Vector2 _pos, Vector2 _sourcePos, Vector2 _sourceSize,Vector2 _spriteSize, int _frames)
        {
            tex = _tex;
            sPos = _sourcePos;
            spriteSize = _spriteSize;
            sourceRect = new Rectangle((int)sPos.X, (int)sPos.Y, (int)sourceSize.X, (int)sourceSize.Y);
            desRect = new Rectangle((int)_pos.X, (int)_pos.Y, (int)spriteSize.X, (int)spriteSize.Y);
        }
        public void Update(GameTime _gt, Vector2 _pos)
        {
            desRect = new Rectangle((int)_pos.X, (int)_pos.Y, (int)spriteSize.X, (int)spriteSize.Y);
        }
        public void Draw(SpriteBatch _sb)
        {
            _sb.Draw(tex, desRect, sourceRect, Color.White);
        }


    }
}
