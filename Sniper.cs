using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Sniper : Weapon
    {
        public Sniper(PointF or) : base("../img/SniperGun.png", or)
        {
            this.delay = 50;
        }

        public override Bullet create_bullet(Soldier s)
        {
            Bullet b = new Bullet("../img/SniperBullet.png", s.img.type, loc.X, loc.Y, 5);
            b.speed = 15;
            b.md = 1500;
            return b;
        }
    }
}
