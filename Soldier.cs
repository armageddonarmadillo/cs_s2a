using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CS_S2A
{
    public class Soldier
    {
        public Drawable img; //Image
        public PointF loc; //Location
        public PointF velocity;
        public float facing_angle = 0;
        public int turn_dir = 0;
        public int walk_dir = 0;
        public int speed = 5;
        public bool shooting = false;

        public Soldier(String path, int x, int y)
        {
            img = new Drawable(path, x, y, 4, 60);
            velocity = new PointF();
            this.loc = new PointF(x, y);
        }

        public void draw(Graphics g)
        {
            img.angle = facing_angle;
            img.draw(g);
        }

        public void update(int time)
        {
            facing_angle += (time / 4) * turn_dir;
            velocity.X = (float)Math.Cos(facing_angle / 180f * Math.PI) * walk_dir * speed;
            velocity.Y = (float)Math.Sin(facing_angle / 180f * Math.PI) * walk_dir * speed;
            move();
            img.update(time);
            fire();

            //collide solider against walls
            foreach (Wall w in Main.walls)
            {
                PointF t = new PointF();
                if (this.wall_collision(w, ref t)) push(t);
            }
        }

        public void move()
        {
            loc.X += velocity.X;
            loc.Y += velocity.Y;
            img.location.X = loc.X - Main.offset.X;
            img.location.Y = loc.Y - Main.offset.Y;
        }

        public void fire()
        {
            if (!shooting) return;
            Bullet b = new Bullet("../img/bullet3.png", img.type, loc.X, loc.Y, 5);
            b.vel.X = (float)Math.Cos(facing_angle / 180f * Math.PI) * b.speed;
            b.vel.Y = (float)Math.Sin(facing_angle / 180f * Math.PI) * b.speed;
            Main.bullets.Add(b);
        }

        public bool wall_collision(Wall w, ref PointF t)
        {
            PointF np = w.nearest_point(this.loc);  //create a new point variable to store the closest point on the wall to the soldier

            float d = (float)Math.Sqrt((np.X - loc.X) * (np.X - loc.X) + (np.Y - loc.Y) * (np.Y - loc.Y)); //calc the hypoteneuse (distance) between this soldier and the wall

            if (d < this.img.image.Width / 2)
            {
                t = np;
                return true;
            }
            return false;
        }

        public void push(PointF p)
        {
            float d = (float)Math.Sqrt((p.X - loc.X) * (p.X - loc.X) + (p.Y - loc.Y) * (p.Y - loc.Y)); //calc the hypoteneuse (distance) between this soldier and the wall

            if (d == 0) return;

            float db = this.img.image.Width / 2 + 1;
            float proportion = db / d;

            PointF back = new PointF(this.loc.X - p.X, this.loc.Y - p.Y);
            back.X *= proportion;
            back.Y *= proportion;

            this.loc.X = p.X + back.X;
            this.loc.Y = p.Y + back.Y;
        }
    }
}
