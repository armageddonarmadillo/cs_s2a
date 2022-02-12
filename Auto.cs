using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Auto : Weapon
    {
        public Auto(PointF or) : base("../img/RapidGun.png", or)
        {
            this.delay = 1;
        }

        public override Bullet create_bullet(Soldier s)
        {
            Bullet b = new Bullet("../img/Bullet2.png", s.img.type, loc.X, loc.Y, 5);
            b.speed = 7;
            b.md = 250;
            return b;
        }
    }
}
