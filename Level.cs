using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_S2A
{
    public class Level
    {
        public static void level_loader(String data)
        {
            string[] file = System.IO.File.ReadAllText("../lvl/" + data + ".txt").Split('\n');
            List<String[]> level = new List<String[]>();

            for (int i = 0; i < file.Length; i++)
                level.Add(file[i].Split('|'));

            for (int i = 0; i < level.Count; i++)
                for (int o = 0; o < level[i].Length; o++)
                    switch (level[i][o].Replace("[", "").Replace("]", "").Trim())
                    {
                        case "W":
                            create_wall("Orange", o * 50, i * 50);
                            break;
                        case "P":
                            place_player(o * 50, i * 50);
                            break;
                    }
        }

        static void create_wall(int x, int y)
        {
            string[] colors = { "Blue", "Orange", "Green" };
            Random r = new Random();
            Main.walls.Add(new Wall(colors[r.Next() % colors.Length], x, y, 50, 50));
        }
        static void create_wall(string color, int x, int y)
        {
            Main.walls.Add(new Wall(color, x, y, 50, 50));
        }
        static void create_enemy(int x, int y)
        {
            //TODO: Add enemy insertion
        }
        static void create_enemy(string variant, int x, int y)
        {
            //TODO: Add enemy insertion
        }
        static void place_player(int x, int y)
        {
            Main.mc.loc = new System.Drawing.PointF(x, y);
        }
    }
}
