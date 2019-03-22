using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Platformer.Sprites;

namespace Platformer.Components
{
    class Hitbox
    {
        Rectangle area;
        int dmg;
        List<Sprite> hitlist;
        Sprite creator;
        Hitbox(Rectangle _area, int _damage, Sprite _creator)
        {
            area = _area;
            dmg = _damage;
            creator = _creator;
        }

        private bool isInList(Sprite _s)
        {
            for (int i = 0; i < hitlist.Count; i++)
            {
                if (hitlist[i] == _s){ return true; }
            }
            return false;
        }

        public void Update(GameTime _gt, List<Sprite> _sl)
        {
            //check list to see if a sprite of type player is hit
            foreach(Solid s in _sl)
            {
                if(s.GetType() == typeof(Player) && creator != s && s.anim.desRect.Intersects(area))
                {
                    //if not in list and is in contact add to list and push
                    if (!isInList(s)) {
                        hitlist.Add(s);
                        s.push = new Vector2(Math.Sign(area.X - s.anim.desRect.X), Math.Sign(area.Y - s.anim.desRect.Y));
                    }
                    
                }
            }
            for (int i = 0; i < hitlist.Count; i++)
            {
                //remove from list if no longer in contact
                if (isInList(hitlist[i]) && !hitlist[i].anim.desRect.Intersects(area))
                {
                    hitlist.RemoveAt(i);
                    i--;
                }
            }
        }

        

    }
}
