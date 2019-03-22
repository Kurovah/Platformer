using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.Components;

namespace Platformer.Sprites
{
    enum states
    {
        idle,
        move,
        inAir,
    };
    class Player:Solid
    {
        KeyboardState ks;
        float xSpd = 0, ySpd= 0, spd,gravity, hp;
        
        public Player(Texture2D _tex, Vector2 _pos, Vector2 _spriteSize)
            :base(_tex,_pos,_spriteSize)
        {
            velocity = new Vector2(0,0);
            push = new Vector2(0, 0);
            gravity = 0.25f;
            spd = 5f;
            anim = new Animation(_tex, _pos, new Vector2(0, 32), new Vector2(32), _spriteSize, 0);
        }

        public override void Update(GameTime _gt, List<Sprite> _sprites)
        {
            ks = Keyboard.GetState();
            Movement();
            Collision(_sprites);
            velocity = new Vector2(xSpd, ySpd);
            base.Update(_gt, _sprites);
        }

        private void Movement()
        {
            if (ks.IsKeyDown(Keys.A))
            {
                xSpd = -spd;
            }
            else if (ks.IsKeyDown(Keys.D))
            {
                xSpd = spd;
            }
            else if (ks.IsKeyDown(Keys.D) && ks.IsKeyDown(Keys.D) || !ks.IsKeyDown(Keys.D) && !ks.IsKeyDown(Keys.D))
            {
                xSpd = 0;
            }
            
        }

        private void Collision(List<Sprite> _sprites)
        {
            //collison
            foreach (Sprite s in _sprites)
            {
                if (s != this && s.GetType() == typeof(Solid))
                {
                    if (checkTop(s))
                    {
                        if (ySpd > 0)
                        {
                            //stop moving and snap  to the top of the other sprite
                            ySpd = 0;
                            pos.Y = s.anim.desRect.Top - anim.desRect.Height;
                        }
                        if (ks.IsKeyDown(Keys.J))
                        {
                            ySpd = -12;
                        }

                    }
                    else
                    {
                        ySpd += gravity;
                    }

                    if (checkBottom(s) && ySpd < 0) { ySpd = 0; }
                    if (checkRight(s) && xSpd < 0) { xSpd = 0; }
                    if (checkLeft(s) && xSpd > 0) { xSpd = 0; }
                }
            }
        }
    }
}
