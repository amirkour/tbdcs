using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boggle;

namespace BoggleTest
{
    [TestClass]
    public class BoggleGraphTest
    {
        [TestMethod]
        public void BoggleGraph_Equals_ReturnsTrue_WhenBothGraphArraysAreNull()
        {
            BoggleGraph g1 = new BoggleGraph();
            BoggleGraph g2 = new BoggleGraph();
            Assert.AreEqual(g1, g2);
            Assert.AreEqual(g2, g1);
        }

        [TestMethod]
        public void BoggleGraph_Equals_ReturnsTrue_WhenEqual()
        {
            BoggleGraph g1 = Utils.BuildRandomGraph(3, 3);
            BoggleGraph g2 = new BoggleGraph(g1.Graph);
            Assert.AreEqual(g1, g2);
            Assert.AreEqual(g2, g1);
        }

        [TestMethod]
        public void BoggleGraph_Equals_ReturnsFalse_WhenOneGraphArrayIsNull()
        {
            BoggleGraph g1 = new BoggleGraph(1, 1);
            BoggleGraph g2 = new BoggleGraph(null);
            Assert.AreNotEqual(g1, g2);
            Assert.AreNotEqual(g2, g1);
        }

        [TestMethod]
        public void BoggleGraph_Equals_ReturnsFalse_WhenUnequal()
        {
            BoggleGraph g1 = Utils.BuildRandomGraph(2, 2);
            BoggleGraph g2 = Utils.BuildRandomGraph(2, 1);
            Assert.AreNotEqual(g1, g2);
            Assert.AreNotEqual(g2, g1);
        }

        [TestMethod]
        public void BoggleGraph_InBounds_ReturnsFalse_WhenOutOfBounds()
        {
            BoggleGraph graph = new BoggleGraph(2, 2);

            BoggleNode dummy = new BoggleNode();
            Assert.IsFalse(graph.InBounds(-1, 0, out dummy));
            Assert.IsNull(dummy);

            dummy = new BoggleNode();
            Assert.IsFalse(graph.InBounds(0, -1, out dummy));
            Assert.IsNull(dummy);

            dummy = new BoggleNode();
            Assert.IsFalse(graph.InBounds(0, 2, out dummy));
            Assert.IsNull(dummy);

            dummy = new BoggleNode();
            Assert.IsFalse(graph.InBounds(2, 0, out dummy));
            Assert.IsNull(dummy);
        }

        [TestMethod]
        public void BoggleGraph_InBounds_ReturnsTrue_WhenInBounds()
        {
            BoggleGraph graph = Utils.BuildRandomGraph(2, 2);

            BoggleNode dummy = null;
            Assert.IsTrue(graph.InBounds(0, 0, out dummy));
            Assert.AreEqual(dummy, graph.Graph[0][0]);

            dummy = null;
            Assert.IsTrue(graph.InBounds(1, 1, out dummy));
            Assert.AreEqual(dummy, graph.Graph[1][1]);

            dummy = null;
            Assert.IsTrue(graph.InBounds(0, 1, out dummy));
            Assert.AreEqual(dummy, graph.Graph[0][1]);

            dummy = null;
            Assert.IsTrue(graph.InBounds(1, 0, out dummy));
            Assert.AreEqual(dummy, graph.Graph[1][0]);

            dummy = null;
            Assert.IsTrue(graph.InBounds(1, 1, out dummy));
            Assert.AreEqual(dummy, graph.Graph[1][1]);
        }

        [TestMethod]
        public void BoggleGraph_GetNeighborsFor_ReturnsNeighbors()
        {
            BoggleGraph graph = Utils.BuildRandomGraph(3, 3);

            ISet<BoggleNode> neighbors = graph.GetNeighborsFor(1, 1);
            Assert.IsTrue(neighbors.Count == 4);
            Assert.IsTrue(neighbors.Contains(graph.Graph[0][1]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[1][0]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[2][1]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[1][2]));

            neighbors = graph.GetNeighborsFor(0, 0);
            Assert.IsTrue(neighbors.Count == 2);
            Assert.IsTrue(neighbors.Contains(graph.Graph[1][0]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[0][1]));

            neighbors = graph.GetNeighborsFor(1, 0);
            Assert.IsTrue(neighbors.Count == 3);
            Assert.IsTrue(neighbors.Contains(graph.Graph[0][0]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[2][0]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[1][1]));

            neighbors = graph.GetNeighborsFor(2, 1);
            Assert.IsTrue(neighbors.Count == 3);
            Assert.IsTrue(neighbors.Contains(graph.Graph[2][0]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[2][2]));
            Assert.IsTrue(neighbors.Contains(graph.Graph[1][1]));
        }

        [TestMethod]
        public void BoggleGraph_GetNeighborsFor_ReturnsEmptySet_WhenOutOfBounds()
        {
            BoggleGraph graph = new BoggleGraph(2, 2);

            ISet<BoggleNode> neighbors = graph.GetNeighborsFor(-1, -1);
            Assert.IsTrue(neighbors.Count <= 0);

            neighbors = graph.GetNeighborsFor(2, 0);
            Assert.IsTrue(neighbors.Count <= 0);
        }
    }
}
