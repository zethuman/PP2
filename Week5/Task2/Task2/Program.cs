using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2
{
    public class Marks
    {
        public int n;

        public Marks() { }

        public Marks(int points)
        {
            n = points;
        }

        public void GetLetter()
        {
            if (n <= 100 && n >= 95)
                Console.WriteLine("A");
            if (n <= 94 && n >= 90)
                Console.WriteLine("A-");
            if (n <= 89 && n >= 85)
                Console.WriteLine("B+");
            if (n <= 84 && n >= 80)
                Console.WriteLine("B");
            if (n <= 79 && n >= 75)
                Console.WriteLine("B-");
            if (n <= 74 && n >= 70)
                Console.WriteLine("C+");
            if (n <= 69 && n >= 65)
                Console.WriteLine("C");
            if (n <= 64 && n >= 60)
                Console.WriteLine("C-");
            if (n <= 59 && n >= 55)
                Console.WriteLine("D+");
            if (n <= 54 && n >= 50)
                Console.WriteLine("D");
            if (n <= 49 && n >= 0)
                Console.WriteLine("F");
            
        }
      

        public void xsLoad()
        {
            FileStream fs = new FileStream("../../marks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Marks>));
            List <Marks> ab = xs.Deserialize(fs) as List<Marks>;
            fs.Close();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Marks> Point = new List<Marks>();
            Point.Add(new Marks(95));
            Point.Add(new Marks(89));

            Console.WriteLine("Result: ");
            foreach (var v in Point)
            {
                v.GetLetter();
            }
            
            FileStream fs = new FileStream("../../marks.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Marks>));
            xs.Serialize(fs, Point);
            fs.Close();

            Console.WriteLine();
            Console.WriteLine("Deserialize result: ");
  

            FileStream fs1 = new FileStream("../../marks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs1 = new XmlSerializer(typeof(List<Marks>));
            List<Marks> ab = xs.Deserialize(fs1) as List<Marks>;
            foreach(var v in ab)
            {
                v.GetLetter();
            }s

            fs1.Close();
            Console.ReadKey();
        }
    }
}