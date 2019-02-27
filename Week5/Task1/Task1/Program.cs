using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    [Serializable]
    public class Complex
    {
        [XmlElement]
        public int a, b;

        public Complex() { }
       
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void Read()
        {
            string[] s = Console.ReadLine().Split('/', ' ');
            a = int.Parse(s[0]);
            b = int.Parse(s[1]);
        }

        public void xsSave()
        {
            FileStream fs = new FileStream("../../complex.xml", FileMode.Truncate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, this);
            fs.Close();
        }

        public static Complex xsLoad()
        {
            Complex x;
            FileStream fs = new FileStream("../../complex.xml", FileMode.Open, FileAccess.Read);

            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            x = xs.Deserialize(fs) as Complex;
            fs.Close();
            return x;

        }

        public static Complex operator +(Complex x, Complex y)
        {
            Complex res = new Complex();
            res.a = x.a * y.b + x.b * y.a;
            res.b = x.b * y.b;
            return res;
        }

        public override string ToString()
        {
            string s = null;
            if (b == 1)
            {
                s = $"{a}";
            }
            else if (b == 0)
            {
                s = "Are you sure, that you know math?";
            }
            else
            {
                s = $"{a}/{b}";
            }
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first complex number as x/y:");
            Complex x = new Complex();
            x.Read();
            Console.WriteLine("Enter second complex number as x/y:");
            Complex y = new Complex();
            y.Read();
            Complex sum = new Complex();

            sum = x + y;
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Result of sum: " + sum);
           
            sum.xsSave();
            Complex h = Complex.xsLoad();

            Console.WriteLine("XmlDeserialize result is: " + h);
            Console.ReadKey();
        }
    }
}