using Lab9_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApp
{
    [TestClass]
    public class PointArrayTest
    {
        [TestMethod]
        public void TestEmptyCtor()
        {
            Point[] points = new Point[0];
            PointArray expected = new PointArray(points);
            PointArray actual = new PointArray();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRandomCtor()
        {
            PointArray ptArr = new PointArray(4);
            Assert.AreEqual(4,ptArr.Points.Length);
        }

        [TestMethod]
        public void TestArrayProp()
        {
            Point[] points = new Point[7];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i, i);
            }
            PointArray expected = new PointArray(points);

            PointArray actual = new PointArray();
            actual.Points = points;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestClosestPointMethod() 
        {
            PointArray ptArr = new PointArray();
            for (int i = 0; i < 10; ++i)
            {
                ptArr += new Point(i, i);
            }

            Point expected = new Point(0, 0);
            Point actual = ptArr.ClosestToCenter(ptArr);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBinaryPlusOp() 
        {
            PointArray ptArr = new PointArray(new Point[10]);
            ptArr += new Point(11, 11);

            Assert.AreEqual(11,ptArr.Points.Length);
        }

        [TestMethod]
        public void TestBinaryMinusOp()
        {
            PointArray ptArr = new PointArray();
            for (int i = 0; i < 5; ++i)
            {
                ptArr += new Point(i, i);
            }

            Point pt = new Point(0, 0);
            ptArr -= pt;

            Assert.AreEqual(4,ptArr.Points.Length);
        }
    }
}
