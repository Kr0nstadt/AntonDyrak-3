using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLibrary.Parsers.States.CircleStates;
using ShapeLibrary.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary.Shapes.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void _pTest()
        {
            Circle exp = new Circle(new Point(0, 0), 2);
            Assert.AreEqual(12.566368, exp._p(),0.001);
        }

        [TestMethod()]
        public void _sTest()
        {
            Circle exp = new Circle(new Point(0, 0), 2);
            Assert.AreEqual(12.56, exp._s(), 0.1);
        }

        [TestMethod()]
        public void IsIntesection_true_Test()
        {
            Circle first = new Circle(new Point(0,0), 2);
            Circle second = new Circle(new Point(1, 2), 3);
            Circle third = new Circle(new Point(6, 8), 1);
            Circle fourth = new Circle(new Point(0, 0), 9);
            Assert.IsTrue(fourth.IsIntesection(fourth));
        }

        [TestMethod()]
        public void IsIntesection_false_Test()
        {
            Circle first = new Circle(new Point(0, 0), 2);
            Circle second = new Circle(new Point(1, 2), 3);
            Circle third = new Circle(new Point(60, 80), 1);
            Circle fourth = new Circle(new Point(0, 0), 9);
            Assert.IsFalse(fourth.IsIntesection(third));
        }

        [TestMethod]
        public void IsIntesection_true_oter_test()
        {
            Circle first = new Circle(new Point(0, 0), 2);
            Circle second = new Circle(new Point(1, 2), 3);
            Circle third = new Circle(new Point(6, 8), 1);
            Circle fourth = new Circle(new Point(0, 0), 9);
            Assert.IsTrue(fourth.IsIntesection(first));
        }
    }
}