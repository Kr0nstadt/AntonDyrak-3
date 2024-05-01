using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLibrary.Parsers.ShapeParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using ShapeLibrary.Exeptions;

namespace ShapeLibrary.Parsers.ShapeParsers.Tests
{
    [TestClass()]
    public class CircleParserTests
    {
        [TestMethod()]
        public void Parse_circle_returt_object()
        {
            string Input = "circle(0 0,2)";
            Circle exp = new Circle(new Point(0, 0), 2);

            CircleParser parser = new CircleParser();
            Circle? circle = parser.Parse(Input) as Circle ?? null;
            
            Assert.IsNotNull(circle);
            Assert.IsTrue(circle._p() == exp._p() &&
                circle._s() == exp._s() &&
                circle.Radius == exp.Radius &&
                circle.Center.X == exp.Center.X &&
                circle.Center.Y == exp.Center.Y);
        }

        [TestMethod]
        public void Parse_more_spase()
        {
            string Input = "circle    (   0 0,  6   )   ";
            Circle exp = new Circle(new Point(0, 0), 6);
            CircleParser parser = new CircleParser();
            Circle? circle = parser.Parse(Input) as Circle ?? null;

            Assert.IsTrue(circle._p() == exp._p() &&
                circle._s() == exp._s() &&
                circle.Radius == exp.Radius &&
                circle.Center.X == exp.Center.X &&
                circle.Center.Y == exp.Center.Y);
        }

        [TestMethod()]
        public void Parse_Exeption_WordState()
        {
            string Input = "circcle(0 0,2)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_OpenBracketState()
        {
            string Input = "circle((0 0,2)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_CircleCenterXState_first()
        {
            string Input = "circle( 9 0 0,2)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_CircleCenterXState_second()
        {
            string Input = "circle(1.0.4  0,2)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_CenterYState_first()
        {
            string Input = "circle( 0 0,2.3.3)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_CenterYState_second()
        {
            string Input = "circle( 0 0, 3,3)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_CommaState()
        {
            string Input = "circle( 0 0 4.5)";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_RadiusState()
        {
            string Input = "circle( 0 0,4,5 )";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_CloseBracketState()
        {
            string Input = "circle( 0 0, 1.5) )";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }

        [TestMethod()]
        public void Parse_Exeption_EndState()
        {
            string Input = "circle( 0 0, 1.5)34";
            CircleParser parser = new CircleParser();
            Assert.ThrowsException<InvalidCharacterExeption>(() => parser.Parse(Input));
        }
    }
}