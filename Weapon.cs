using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public abstract class Weapon
    {
        public Drawable img;
        public PointF loc;

        public int counter, delay;
        public float angle, dist, speed;

        public Weapon(string path, PointF or)
        {
            this.img = new Drawable(path, or.X, or.Y, 1, 1);
            this.loc = or;
        }

        public abstract Bullet create_bullet(Soldier s);

        public void draw(Graphics g)
        {
            img.angle = angle;
            img.location.X = loc.X - Main.offset.X;
            img.location.Y = loc.Y - Main.offset.Y;

            img.draw(g);
        }

        public void update(int time, PointF loc, float angle, string type, bool shooting, Soldier parent)
        {
            float xo = (float)Math.Cos(angle / 180f * Math.PI) * 32f;
            float yo = (float)Math.Sin(angle / 180f * Math.PI) * 32f;
            this.loc.X = loc.X + xo;
            this.loc.Y = loc.Y + yo;
            this.angle = angle;
            if (counter++ > delay)
            {
                counter = 0;
                if (shooting) fire(parent);
            }
        }

        public void fire(Soldier parent)
        {
            Bullet b = create_bullet(parent);
            b.vel.X = (float)Math.Cos(angle / 180f * Math.PI) * b.speed;
            b.vel.Y = (float)Math.Sin(angle / 180f * Math.PI) * b.speed;
            Main.bullets.Add(b);
        }
    }
}
