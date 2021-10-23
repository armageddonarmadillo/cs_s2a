using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CS_S2A
{
    public class Player
    {
        public Drawable img; //Image
        public PointF loc; //Location

        public Player(int x, int y)
        {
            img = new Drawable("../img/Player_1.png", x, y);
            loc = img.location;
        }

        public void draw(Graphics g)
        {
            img.draw(g);
        }
    }
}
