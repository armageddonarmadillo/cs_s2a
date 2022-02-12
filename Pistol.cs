using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Pistol : Weapon
    {

        public Pistol(PointF or) : base("../img/Pistol.png", or)
        {
            this.delay = 1;
        }

        public override Bullet create_bullet(Soldier s)
        {
            Bullet b = new Bullet("../img/bullet3.png", s.img.type, loc.X, loc.Y, 5);
            b.speed = 5;
            b.md = 5000;
            return b;
        }
    }
}
