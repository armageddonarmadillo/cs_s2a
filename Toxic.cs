using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Toxic : Weapon
    {
        public Toxic(PointF or) : base("../img/toxic_cannon.png", or)
        {
            this.delay = 1;
        }

        public override Bullet create_bullet(Soldier s)
        {
            Bullet b = new Bullet("../img/toxic_bullet.png", s.img.type, loc.X, loc.Y, 5);
            b.speed = 7;
            b.md = 250;
            return b;
        }
    }
}
