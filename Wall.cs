using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CS_S2A
{
    public class Wall
    {
        public Drawable img;
        public int x, y, w, h;

        public Wall(string color, int x, int y, int w, int h)
        {
            img = new Drawable("../img/" + color + "Box.png", x, y, 1, 1);
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public void draw(Graphics g)
        {
            img.location.X = x - Main.offset.X;
            img.location.Y = y - Main.offset.Y;
            g.DrawImage(img.image, new Rectangle((int)img.location.X, (int)img.location.Y, w, h));
        }

        public PointF nearest_point(PointF p)
        {
            PointF np = new PointF();                               //create a new point represting the nearest point

            if (this.x > p.X) np.X = this.x;                        //if left edge of wall is to the right of point p
            else if (this.x + this.w < p.X) np.X = this.x + this.w; //if right edge of wall is to the left of point p
            else np.X = p.X;                                        //default - set np to p

            if (this.y > p.Y) np.Y = this.y;                        //if top edge of wall is below the top of point p
            else if (this.y + this.h < p.Y) np.Y = this.y + this.h; //if bottom edge of wall is below the top of p
            else np.Y = p.Y;                                        //default set np to p

            return np;                                              //return the newly filled np object         
        }

        public PointF normal(PointF p)
        {
            PointF np = nearest_point(p);

            PointF normal = new PointF(p.X - np.X, p.Y - np.Y);

            if (normal.X == 0 && normal.Y == 0) return normal;

            float factor = 1f / (float)Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y);

            normal.X *= factor;
            normal.Y *= factor;

            return normal;
        }
    }
}
