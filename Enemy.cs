using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_S2A
{
    public class Enemy : Soldier
    {
        int hp = 5;
        int counter = 0, delay = 30;
        public Enemy(int x, int y) : base("../img/Enemy2.png", x, y)
        {
            turn_dir = 0;
            walk_dir = 1;
            shooting = true;
            img.type = "enemy";
        }

        public void update(int time)
        {
            base.update(time);
            collide_with_bullets();
            if (counter++ > delay) { follow_player(); counter = 0; }
            //if (hp <= 0) walk_dir = 0;
        }

        public void collide_with_bullets()
        {
            foreach (Bullet b in Main.bullets)
            {
                if (b.type != this.img.type && b.img.collides(this.img))
                {
                    b.active = false;
                    hp--;
                }
            }
        }

        public void follow_player()
        {
            int px = (int)Main.mc.loc.X;        //Player X
            int ex = (int)this.loc.X;           //Enemy X
            int py = (int)Main.mc.loc.Y;        //Player Y
            int ey = (int)this.loc.Y;           //Enemy Y
            int dx = ex - px;                   //Difference along X
            int dy = ey - py;                   //Difference along Y

            facing_angle = ((float)Math.Atan(dy / dx == 0 ? ex / (Math.Abs(ex)) : dx) + (float)(ex >= px ? Math.PI : 0)) * (float)(180 / Math.PI);
        }
    }
}
