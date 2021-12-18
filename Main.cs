using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_S2A
{
    /*
     * Shooting
     * Create Soldiers
     * Move Soldiers
     * Hitboxes (collisions)
     * Bullet reflection
     */
    public partial class Main : Form
    {
        //Game Variables
        public static Player mc;
        Enemy e1;
        Graphics wg; //Windows Graphics
        Graphics buffer_wg; //Buffer Windows Graphics
        Bitmap buffer;
        public static Point offset;

        //Control Variables
        bool started, end, paused;

        //Game Lists
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Wall> walls = new List<Wall>();

        public Main()
        {
            InitializeComponent();
            wg = this.CreateGraphics();
            buffer = new Bitmap(this.Width, this.Height);
            buffer_wg = Graphics.FromImage(buffer);

            //set render to be called when the window repaints the frame
            this.Paint += new PaintEventHandler(render);

            init();
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            mc.update(gametimer.Interval);
            e1.update(gametimer.Interval);
            foreach (Bullet b in bullets) b.update();

            offset.X = (int)mc.loc.X - this.Width / 2;
            offset.Y = (int)mc.loc.Y - this.Height / 2;

            //clean up inactive objects
            housekeeping();
            //this event needs a PaintEventArgs to describe what should happen during [it]
            OnPaint(new PaintEventArgs(wg, new Rectangle(0, 0, this.Width, this.Height)));
        }

        void init()
        {
            mc = new Player(225, 225);
            e1 = new Enemy(425, 425);

            //creating some walls
            walls.Add(new Wall("Blue", 0, 0, this.Width, 10));                      //TOP
            walls.Add(new Wall("Blue", 0, this.Height - 50, this.Width, 10));       //BOTTOM
            walls.Add(new Wall("Orange", 0, 0, 10, this.Height));                   //LEFT              
            walls.Add(new Wall("Orange", this.Width - 25, 0, 10, this.Height));     //RIGHT

            //change input from screen's handler to player's handler
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(mc.key_down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(mc.key_up);
        }

        void render(Object sender, PaintEventArgs e)
        {
            //Clear screen before rendering
            buffer_wg.Clear(Color.FromArgb(255, 174, 200));
            mc.draw(buffer_wg);
            e1.draw(buffer_wg);
            foreach (Bullet b in bullets) b.draw(buffer_wg);
            foreach (Wall w in walls) w.draw(buffer_wg);

            //Render ends here, don't add more after this
            wg.DrawImage(buffer, new Point(0, 0));
        }

        void housekeeping() //removes inactive objects from lists
        {
            foreach (Bullet b in bullets) if (!b.active) { bullets.Remove(b); break; }
        }
    }
}
