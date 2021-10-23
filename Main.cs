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
         Screen Clearing
         Player object
         Enemy object
         Shooting
         Double Buffering
     */
    public partial class Main : Form
    {
        //Game Variables
        Player mc;
        Drawable thing2;
        Graphics wg; //Windows Graphics
        Graphics buffer_wg; //Buffer Windows Graphics
        Bitmap buffer;

        //Control Variables
        bool started, end, paused;

        //Game Lists

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
            thing2.angle += gametimer.Interval / 4;
            //this event needs a PaintEventArgs to describe what should happen during [it]
            OnPaint(new PaintEventArgs(wg, new Rectangle(0, 0, this.Width, this.Height)));
        }

        void init()
        {
            mc = new Player(225, 225);
            thing2 = new Drawable("../img/Enemy_1.png", 425, 425);
        }

        void render(Object sender, PaintEventArgs e)
        {
            //Clear screen before rendering
            buffer_wg.Clear(Color.FromArgb(255, 174, 200));
            mc.draw(buffer_wg);
            thing2.draw(buffer_wg);

            //Render ends here, don't add more after this
            wg.DrawImage(buffer, new Point(0, 0));
        }
    }
}
