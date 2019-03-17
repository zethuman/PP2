using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sample
{
    class Wall
    {
        public static void Level(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string s = sr.ReadToEnd();
            Console.WriteLine(s);
            sr.Close();
        }
    }
}
