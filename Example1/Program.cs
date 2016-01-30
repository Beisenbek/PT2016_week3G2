using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Example1
{
    [Serializable]
    public class Point
    {
        public Info info = new Info();
        private int x;
        public int y;
        public Point()
        {
            x = 10;
            y = 10;
           
        }
        public void SetInfo()
        {
            info.owner = "Baisakov";
            info.version = "2.0";
        }
    }

    [Serializable]
    public class Info
    {
        [NonSerialized]
        public string owner;
        public string version;
    }

    class Program
    {
        static void Main(string[] args)
        {
            F3();
            F4();
        }

        /// <summary>
        /// пример десериализации на основе BinaryFormatter
        /// </summary>
        private static void F4()
        {
            Point p = new Point();
            FileStream fs = new FileStream("point.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            p = bf.Deserialize(fs) as Point;

            fs.Close();
            Console.WriteLine(p.info.version + " " + p.info.owner);
        }

        /// <summary>
        /// пример сериализации на основе BinaryFormatter
        /// </summary>
        private static void F3()
        {
            Point p = new Point();
            p.SetInfo();
            FileStream fs = new FileStream("point.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, p);

            fs.Close();
        }
        /// <summary>
        /// пример десериализации на основе XmlSerializer
        /// </summary>
        private static void F2()
        {
            FileStream fs = new FileStream("point.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Point));
            Point p2 = xs.Deserialize(fs) as Point;
            fs.Close();
            Console.WriteLine(p2.info.owner + " " + p2.info.version);
        }
        /// <summary>
        /// пример сериализации на основе XmlSerializer
        /// </summary>
        private static void F1()
        {
            Point p = new Point();
            p.SetInfo();

            FileStream fs = new FileStream("point.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Point));
            xs.Serialize(fs, p);

            fs.Close();
        }
    }
}