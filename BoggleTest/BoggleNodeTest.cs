using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle;

namespace BoggleTest
{
    [TestClass]
    public class BoggleNodeTest
    {
        [TestMethod]
        public void BoggleNode_IsImmediatelyAbove_ReturnsTrue_WhenCallerIsImmediatelyAboveArg()
        {
            BoggleNode n1 = new BoggleNode();
            BoggleNode n2 = new BoggleNode();

            n1.X = 10;
            n1.Y = 4;

            n2.X = n1.X;
            n2.Y = n1.Y + 1;

            Assert.IsTrue(n1.IsImmediatelyAbove(n2));
        }

        [TestMethod]
        public void BoggleNode_IsImmediatelyAbove_ReturnsFalse_WhenCallerIsNotImmediatelyAboveArg()
        {
            BoggleNode n1 = new BoggleNode();
            BoggleNode n2 = new BoggleNode();

            n1.X = 10;
            n1.Y = 10;

            // left,down
            n2.X = n1.X - 1;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyAbove(n2));

            // left
            n2.X = n1.X - 1;
            n2.Y = n1.Y;
            Assert.IsFalse(n1.IsImmediatelyAbove(n2));

            // left,up
            n2.X = n1.X - 1;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyAbove(n2));

            // right,up
            n2.X = n1.X + 1;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyAbove(n2));

            // right
            n2.X = n1.X + 1;
            n2.Y = n1.Y;
            Assert.IsFalse(n1.IsImmediatelyAbove(n2));

            // right,down
            n2.X = n1.X + 1;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyAbove(n2));
        }

        [TestMethod]
        public void BoggleNode_IsImmediatelyBelow_ReturnsTrue_WhenCallerIsImmediatelyBelowArg()
        {
            BoggleNode n1 = new BoggleNode();
            BoggleNode n2 = new BoggleNode();

            n1.X = n1.Y = 10;
            n2.Y = n1.Y - 1;
            n2.X = n1.X;
            Assert.IsTrue(n1.IsImmediatelyBelow(n2));
        }

        [TestMethod]
        public void BoggleNode_IsImmediatelyBelow_ReturnsFalse_WhenCallerIsNotImmediatelyBelowArg()
        {
            BoggleNode n1 = new BoggleNode();
            BoggleNode n2 = new BoggleNode();

            n1.X = n1.Y = 10;

            // top-left
            n2.X = n1.X + 1;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));

            // top
            n2.X = n1.X;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));

            // top-right
            n2.X = n1.X - 1;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));

            // right
            n2.X = n1.X - 1;
            n2.Y = n1.Y;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));

            // bottom-right
            n2.X = n1.X - 1;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));

            // bottom-left
            n2.X = n1.X + 1;
            n1.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));

            // left
            n2.X = n1.X + 1;
            n2.Y = n1.Y;
            Assert.IsFalse(n1.IsImmediatelyBelow(n2));
        }

        [TestMethod]
        public void BoggleNode_IsImmediatelyLeftOf_ReturnsTrue_WhenCallerIsImmediatelyLeftOfArg()
        {
            BoggleNode n1 = new BoggleNode();
            BoggleNode n2 = new BoggleNode();

            n1.X = n1.Y = 10;
            n2.X = n1.X + 1;
            n2.Y = n1.Y;
            Assert.IsTrue(n1.IsImmediatelyLeftOf(n2));
        }

        [TestMethod]
        public void BoggleNode_IsImmediatelyLeftOf_ReturnsFalse_WhenCallerIsNotImmediatelyLeftOfArg()
        {
            BoggleNode n1 = new BoggleNode();
            BoggleNode n2 = new BoggleNode();

            n1.X = n1.Y = 10;

            // top-left
            n2.X = n1.X + 1;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));

            // top
            n2.X = n1.X;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));

            // top-right
            n2.X = n1.X - 1;
            n2.Y = n1.Y + 1;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));

            // right
            n2.X = n1.X - 1;
            n2.Y = n1.Y;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));

            // bottom-right
            n2.X = n1.X - 1;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));

            // bottom
            n2.X = n1.X;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));

            // bottom-left
            n2.X = n1.X + 1;
            n2.Y = n1.Y - 1;
            Assert.IsFalse(n1.IsImmediatelyLeftOf(n2));
        }
    }
}
