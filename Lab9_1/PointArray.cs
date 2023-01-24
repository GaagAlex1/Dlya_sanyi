using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Lab9_1
{
    public partial class PointArray
    {
        private Point[] points;
        Random rnd = new Random();

        public Point this[int i]
        {
            get => points[i];
            set => points[i] = value;
        }

        public Point[] Points {
            get { return points; }
            set { points = value; }
        }

        public PointArray() 
        {
            points = new Point[0];
        }

        public PointArray(int sz)
        {
            points = new Point[sz];
            for (int i = 0; i < sz; ++i)
            {
                points[i] = new Point(rnd.Next(1,15),rnd.Next(1,15));
            }
        }
        
        public PointArray(Point[] ptArr)
        {
            int sz = ptArr.Length;
            points = new Point[sz];
            for (int i = 0; i < sz; ++i)
            {
                points[i] = ptArr[i];
            }
        }

        private void Resize(ref PointArray pointArray, int sz)
        {
            Array.Resize(ref pointArray.points, sz);
        }

        private void Delete(PointArray source, Point pt)
        {
            int index = Array.IndexOf(source.points, pt);
            for (int i = index; i < source.points.Length - 1; i++)
            {
                source[i] = source[i + 1];
            }
            Resize(ref source, source.Points.Length - 1);
        }

        public static PointArray operator +(PointArray ptArr, Point pt)
        {
            ptArr.Resize(ref ptArr, ptArr.Points.Length + 1);
            ptArr[ptArr.Points.Length - 1] = pt;
            return ptArr;
        }

        public static PointArray operator -(PointArray ptArr, Point pt)
        {

            ptArr.Delete(ptArr, pt);
            return ptArr;
        }

        public Point ClosestToCenter(PointArray ptArr)
        {
            double minDist = double.MaxValue;
            Point closestPoint = ptArr[0];
            foreach (Point pt in ptArr)
            {
                if (minDist > pt.countDistance(new Point()))
                {
                    minDist = pt.countDistance(new Point());
                    closestPoint = pt;
                }
            }
            return closestPoint;
        }

        public override bool Equals(object obj)
        {
            if (((PointArray)obj).points.Length != points.Length) return false;
            for (int i = 0; i < ((PointArray)obj).points.Length; i++)
            {
                if (points[i] != ((PointArray)obj).points[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
