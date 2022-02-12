using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Super : Weapon
    {
        public Super(PointF or) : base("../img/SuperBallLauncher.png", or)
        {
            this.delay = 10;
        }

        public override Bullet create_bullet(Soldier s)
        {
            Bullet b = new Bullet("../img/SuperBall.png", s.img.type, loc.X, loc.Y, 5);
            b.speed = 10;
            b.md = 500;
            return b;
        }
    }
}
