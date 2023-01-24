using Lab9_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void TestEmptyCtor()
        {
            Point expected = new Point(0, 0);
            Point actual = new Point();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProp()
        {
            Point expected = new Point(1,2);
            Point actual = new Point();
            actual.X = 1f;
            actual.Y = 2f;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCountDist()
        {
            double expected = Point.countDistance(new Point(1,2), new Point(3,4));

            Point pt = new Point(1,2);
            double actual = pt.countDistance(new Point(3, 4));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUnarOperatorPP()
        {
            Point pt = new Point(5,6);
            Point incrPt = new Point(6,7);

            Assert.AreEqual(pt++,incrPt);
        }

        [TestMethod]
        public void TestUnarOperatorMM()
        {
            Point pt = new Point(5,6);
            Point dcrPt = new Point(4,5);

            Assert.AreEqual(pt--,dcrPt);
        }

        [TestMethod]
        public void TestPlusOperator1()
        {
            Point pt1 = new Point(1,2);
            Point pt2 = new Point(2,3);

            Assert.AreEqual(pt1+pt2, Point.countDistance(pt1,pt2));
        }

        [TestMethod]
        public void TestPlusOperator2()
        {
            Point pt = new Point(9, 10);

            Assert.AreEqual(pt + 2, 2 + pt);
        }

        [TestMethod]
        public void TestIntOperator() 
        {
            int expected = 1;
            int actual = (int)(new Point(1.7f,2.5f));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDoubleOperator() 
        {
            double expected = 4.2f;
            double actual = (double)(new Point(3.7f,4.2f));

            Assert.AreEqual(expected, actual);
        }
    }
}
