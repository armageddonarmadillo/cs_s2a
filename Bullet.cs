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
            img = new Drawable(path, x, y);
            vel = new PointF();
            loc = new PointF(x, y);
            radius = img.image.Width / 2;
            this.speed = speed;
        }

        public void draw(Graphics g)
        {
            img.draw(g);
        }

        public void update()
        {
            move();
        }

        public void move()
        {
            loc.X += vel.X;
            loc.Y += vel.Y;
            img.location.X = loc.X - Main.offset.X;
            img.location.Y = loc.Y - Main.offset.Y;
            dt += (int)Math.Abs(vel.X) + (int)Math.Abs(vel.Y);
            active = dt < md;
        }
    }
}
