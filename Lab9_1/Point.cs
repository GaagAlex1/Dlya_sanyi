using System;

namespace Lab9_1
{
    public class Point
    {
        private double x;
        private double y;

        public static int amount;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point()
        {
            x = 0;
            y = 0;
            amount++;
        }

        public Point (double coord1, double coord2)
        {
            x = coord1;
            y = coord2;
            amount++;
        }

        public double countDistance(Point to)
        {
            return Math.Sqrt(Math.Pow(x - to.x, 2) + Math.Pow(y - to.y, 2));
        }

        public static double countDistance(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(first.x - second.x,2) + Math.Pow(first.y - second.y,2));
        }

        public static Point operator ++(Point pt)
        {
            pt.x++;
            pt.y++;
            return pt;
        }

        public static Point operator --(Point pt)
        {
            pt.x--;
            pt.y--;
            return pt;
        }

        public static explicit operator int(Point pt)
        {
            return (int)pt.x;
        }

        public static implicit operator double(Point pt) 
        {
            return pt.y;
        }

        public static double operator +(Point pt1, Point pt2)
        {
            return countDistance(pt1,pt2);
        }

        public static Point operator +(double number, Point pt)
        {
            pt.x += number;
            return pt;
        }

        public static Point operator +(Point pt, double number)
        {
            pt.x += number;
            return pt;
        }

        public override bool Equals(object obj)
        {
            return this.x == ((Point)obj).x
                && this.y == ((Point)obj).y;
        }
    }
}
