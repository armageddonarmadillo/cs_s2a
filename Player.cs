using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CS_S2A
{
    public class Player : Soldier
    {
        int delay = 10, counter = 10;

        public Player(int x, int y) : base("../img/Player_1.png", x, y)
        {
            img.type = "player";
        }

        public void key_down(Object sender, KeyEventArgs e)
        {
            turn_dir = e.KeyCode == Keys.A ? -1 : e.KeyCode == Keys.D ? 1 : turn_dir;
            walk_dir = e.KeyCode == Keys.S ? -1 : e.KeyCode == Keys.W ? 1 : walk_dir;
            //shooting = e.KeyCode == Keys.Space ? e.KeyCode == Keys.Space : shooting;

            if (e.KeyCode == Keys.Space)
            {
                if (counter++ > delay)
                {
                    shooting = true;
                    counter = 0;
                }
                else
                {
                    shooting = false;
                }
            }
        }

        public void key_up(Object sender, KeyEventArgs e)
        {
            turn_dir = e.KeyCode == Keys.A || e.KeyCode == Keys.D ? 0 : turn_dir;
            walk_dir = e.KeyCode == Keys.W || e.KeyCode == Keys.S ? 0 : walk_dir;
            shooting = e.KeyCode == Keys.Space ? !(e.KeyCode == Keys.Space) : shooting;
        }
    }
}
