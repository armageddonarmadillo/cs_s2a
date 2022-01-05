using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Bullet
    {
        public Drawable img; //image for the bullet
        public PointF loc;   //location
        public PointF vel;   //velocity
        public bool active = true;
        public int dt = 0, md = 300;
        public int radius;
        public int speed = 0;
        public string type = "";

        public Bullet(string path, string type, float x, float y, int speed)
        {
            this.type = type;
            img = new Drawable(path, x, y, 4, 25);
            vel = new PointF();
            loc = new PointF(x, y);
            radius = img.image.Width / 2;
            this.speed = speed;
        }

        public void draw(Graphics g)
        {
            img.draw(g);
        }

        public void update(int time)
        {
            move();
            img.update(time);
        }

        public void move()
        {
            loc.X += vel.X;
            loc.Y += vel.Y;
            img.location.X = loc.X - Main.offset.X;
            img.location.Y = loc.Y - Main.offset.Y;
            dt += (int)Math.Abs(vel.X) + (int)Math.Abs(vel.Y);
            active = dt < md;

            foreach (Wall w in Main.walls)
                if (wall_collision(w))
                {
                    back();
                    push(w.normal(loc));
                }
        }

        public bool wall_collision(Wall w)
        {
            PointF np = w.nearest_point(this.loc);  //create a new point variable to store the closest point on the wall to the soldier

            float d = (float)Math.Sqrt((np.X - loc.X) * (np.X - loc.X) + (np.Y - loc.Y) * (np.Y - loc.Y)); //calc the hypoteneuse (distance) between this soldier and the wall

            if (d < this.img.image.Width / 2) return true;
            return false;
        }

        public void push(PointF normal)
        {
            //vector called r for the reflection (r = i - 2b)
            PointF r;

            //2b
            float dot = (vel.X * normal.X + vel.Y * normal.Y) * 2;

            //r is new velocity, i is old velocity.. * dot for bounce
            r = new PointF(vel.X - normal.X * dot, vel.Y - normal.Y * dot);

            //apply reflection
            vel.X = r.X;
            vel.Y = r.Y;
        }

        public void back()
        {
            this.loc.X -= this.vel.X;
            this.loc.Y -= this.vel.Y;
        }
    }
}
