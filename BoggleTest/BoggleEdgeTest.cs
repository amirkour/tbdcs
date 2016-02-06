using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle;
namespace BoggleTest
{
    [TestClass]
    public class BoggleEdgeTest
    {
        [TestMethod]
        public void BoggleEdge_Equals_WhenOneEdgeIsNull_ReturnsFalse()
        {
            BoggleEdge one = new BoggleEdge();
            BoggleEdge two = null;
            Assert.IsFalse(one.Equals(two));
        }

        [TestMethod]
        public void BoggleEdge_Equals_WhenEitherVertexIsNull_ReturnsFalse()
        {
            BoggleNode vOne = new BoggleNode(0, 0);
            BoggleNode vTwo = new BoggleNode(1, 0);

            BoggleEdge one = new BoggleEdge(vOne, vTwo);
            BoggleEdge two = new BoggleEdge(vOne, null);
            Assert.IsFalse(one.Equals(two));
            Assert.IsFalse(two.Equals(one));
            
            two.VertexOne = null;
            two.VertexTwo = vTwo;
            Assert.IsFalse(one.Equals(two));
            Assert.IsFalse(two.Equals(one));

            one.VertexOne = null;
            one.VertexTwo = vTwo;
            two.VertexOne = vOne;
            two.VertexTwo = vTwo;
            Assert.IsFalse(one.Equals(two));
            Assert.IsFalse(two.Equals(one));

            one.VertexOne = vOne;
            one.VertexTwo = null;
            two.VertexOne = vOne;
            two.VertexTwo = vTwo;
            Assert.IsFalse(one.Equals(two));
            Assert.IsFalse(two.Equals(one));
        }

        [TestMethod]
        public void BoggleEdge_Equals_WhenAllVerticesAreNull_ReturnsTrue()
        {
            BoggleEdge one = new BoggleEdge(null, null);
            BoggleEdge two = new BoggleEdge(null, null);
            Assert.IsTrue(one.Equals(two));
            Assert.IsTrue(two.Equals(one));
        }

        [TestMethod]
        public void BoggleEdge_Equals_ReturnsTrueWhenBothAreEqual()
        {
            BoggleNode vOne = new BoggleNode(0, 0);
            BoggleNode vTwo = new BoggleNode(1, 0);

            BoggleEdge one = new BoggleEdge(vOne, vTwo);
            BoggleEdge two = new BoggleEdge(vOne, vTwo);

            Assert.IsTrue(one.Equals(two));
            Assert.IsTrue(two.Equals(one));

            // now swap the vertex orders - the edges should still be equal
            one.VertexOne = vOne;
            one.VertexTwo = vTwo;
            two.VertexOne = vTwo;
            two.VertexTwo = vOne;
            Assert.IsTrue(one.Equals(two));
            Assert.IsTrue(two.Equals(one));
        }
    }
}
