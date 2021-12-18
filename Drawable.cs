using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CS_S2A
{
    public class Drawable
    {
        public Bitmap image;
        public PointF location;
        public PointF offset;
        public float angle = 0f;
        public String type = "";

        public Drawable(string path, float x, float y)
        {
            image = new Bitmap(path);
            location = new PointF(x, y);
            offset = new PointF(image.Width / 2, image.Height / 2);
        }

        public void draw(Graphics g)
        {
            Point draw_location = new Point(
                    (int)(location.X - offset.X),
                    (int)(location.Y - offset.Y)
                );

            Matrix m = new Matrix(); //init empty matrix (matrix' are number systems for 2/3D visual elements)
            m.RotateAt(angle, location); //rotate the matrix about the location with a given angle
            g.Transform = m; //apply modified matrix to graphics object
            g.DrawImage(
                image,
                new Rectangle(draw_location.X, draw_location.Y, image.Width, image.Height),
                new Rectangle(0, 0, image.Width, image.Height),
                GraphicsUnit.Pixel
                );
        }

        public bool collides(Drawable e)
        {
            return (
                    this.location.X < e.location.X + e.image.Width &&
                    this.location.X + this.image.Width > e.location.X &&
                    this.location.Y < e.location.Y + e.image.Height &&
                    this.location.Y + this.image.Height > e.location.Y
                );
        }
    }
}
