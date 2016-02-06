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
        public void BoggleGraph_Contains_Node_WhenNodeNotPresent_ReturnsFalse()
        {
            BoggleGraph graph = new BoggleGraph();
            Assert.IsFalse(graph.Contains(new BoggleNode()));
        }

        [TestMethod]
        public void BoggleGraph_Contains_Node_WhenNodePresent_ReturnsTrue()
        {
            BoggleNode node = new BoggleNode(0, 1);
            BoggleGraph graph = new BoggleGraph();
            graph.Add(node);
            Assert.IsTrue(graph.Contains(node));
        }

        [TestMethod]
        public void BoggleGraph_Contains_Edge_WhenEdgeNotPresent_ReturnsFalse()
        {
            Assert.IsFalse(new BoggleGraph().Contains(new BoggleEdge()));
        }

        [TestMethod]
        public void BoggleGraph_Contains_Edge_WhenEdgePresent_ReturnsTrue()
        {
            BoggleEdge edge = new BoggleEdge(new BoggleNode(0, 0), new BoggleNode(1, 0));
            BoggleGraph graph = new BoggleGraph();
            graph.Add(edge);
            Assert.IsTrue(graph.Contains(edge));
        }

        [TestMethod]
        public void BoggleGraph_Add_Node_ReturnsTheGraph()
        {
            BoggleGraph graph = new BoggleGraph();
            Assert.AreEqual(graph, graph.Add(new BoggleNode()));
        }

        [TestMethod]
        public void BoggleGraph_Add_Node_AddsTheNode()
        {
            BoggleGraph graph = new BoggleGraph();
            Assert.IsTrue(graph.NodeCount == 0);

            graph.Add(new BoggleNode());
            Assert.IsTrue(graph.NodeCount == 1);
        }

        [TestMethod]
        public void BoggleGraph_Add_Node_DoesntAddDupes()
        {
            BoggleNode node = new BoggleNode(0, 0);
            BoggleGraph graph = new BoggleGraph();

            graph.Add(node);
            Assert.IsTrue(graph.NodeCount == 1);
            graph.Add(node);
            Assert.IsTrue(graph.NodeCount == 1);
            graph.Add(node);
            Assert.IsTrue(graph.NodeCount == 1);
        }

        [TestMethod]
        public void BoggleGraph_Add_Edge_ReturnsTheGraph()
        {
            BoggleGraph graph = new BoggleGraph();
            Assert.AreEqual(graph, graph.Add(new BoggleEdge()));
        }

        [TestMethod]
        public void BoggleGraph_Add_Edge_AddsTheNode()
        {
            BoggleGraph graph = new BoggleGraph();
            Assert.IsTrue(graph.EdgeCount == 0);

            graph.Add(new BoggleEdge());
            Assert.IsTrue(graph.EdgeCount == 1);
        }

        [TestMethod]
        public void BoggleGraph_Add_Edge_DoesntAddDupes()
        {
            BoggleEdge edge = new BoggleEdge(new BoggleNode(0, 0), new BoggleNode(1, 0));
            BoggleGraph graph = new BoggleGraph();

            graph.Add(edge);
            Assert.IsTrue(graph.EdgeCount == 1);
            graph.Add(edge);
            Assert.IsTrue(graph.EdgeCount == 1);
            graph.Add(edge);
            Assert.IsTrue(graph.EdgeCount == 1);
        }

        [TestMethod]
        public void BoggleGraph_Equals_ReturnsTrueWhenEquals_RegardlesOfNodeOrdering()
        {
            BoggleGraph g1 = new BoggleGraph();
            BoggleGraph g2 = new BoggleGraph();

            BoggleNode n1 = new BoggleNode(0, 0);
            BoggleNode n2 = new BoggleNode(1, 0);
            BoggleNode n3 = new BoggleNode(2, 0);

            // insert nodes out of order to verify that ordering doesn't effect graph equality
            g1.Add(n1);
            g1.Add(n2);
            g1.Add(n3);
            g2.Add(n3);
            g2.Add(n1);
            g2.Add(n2);

            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void BoggleGraph_Equals_ReturnsTrueWhenEquals_RegardlesOfEdgeOrdering()
        {
            BoggleGraph g1 = new BoggleGraph();
            BoggleGraph g2 = new BoggleGraph();

            BoggleEdge e1 = new BoggleEdge(new BoggleNode(0, 0), new BoggleNode(1, 0));
            BoggleEdge e2 = new BoggleEdge(new BoggleNode(0, 0), new BoggleNode(0, 1));
            BoggleEdge e3 = new BoggleEdge(new BoggleNode(1, 0), new BoggleNode(1, 1));

            // insert edges out of order to verify that ordering doesn't effect graph equality
            g1.Add(e1);
            g1.Add(e2);
            g1.Add(e3);
            g2.Add(e3);
            g2.Add(e1);
            g2.Add(e2);

            Assert.AreEqual(g1, g2);
        }

        [TestMethod]
        public void BoggleGraph_Equals_ReturnsFalse_WhenGraphsAreUnequal()
        {
            BoggleGraph g1 = new BoggleGraph();
            BoggleGraph g2 = new BoggleGraph();

            g1.Add(new BoggleNode());
            Assert.AreNotEqual(g1, g2);

            g1 = new BoggleGraph();
            g1.Add(new BoggleEdge());
            Assert.AreNotEqual(g1, g2);

            g2.Add(new BoggleEdge(new BoggleNode(0, 1), null));
            Assert.AreNotEqual(g1, g2);
        }

        //[TestMethod]
        public void BoggleGraph_GetNeighborsFor_ReturnsEmptyListForNullNode()
        {
            ISet<BoggleNode> neighbors = new BoggleGraph().GetNeighborsFor(null);
            Assert.IsNotNull(neighbors);
            Assert.IsTrue(neighbors.Count <= 0);
        }

        [TestMethod]
        public void BoggleGraph_GetNeighborsFor_ReturnsEmptyListIfThereAreNoNeighbors()
        {
            BoggleGraph graph = new BoggleGraph();
            BoggleNode node = new BoggleNode(10, 10);

            // throw a few rando nodes in there, making sure they're not neighbors to our node
            graph.Add(new BoggleNode(node.X + 5, node.Y + 1));
            graph.Add(new BoggleNode(node.X + 1, node.Y + 5));
            graph.Add(new BoggleEdge()
            {
                VertexOne = new BoggleNode(1, 2),       // throw an edge in, with nodes != node
                VertexTwo = new BoggleNode(123, 234)
            });

            ISet<BoggleNode> neighbors = graph.GetNeighborsFor(node);
            Assert.IsNotNull(neighbors);
            Assert.IsTrue(neighbors.Count <= 0);
        }

        [TestMethod]
        public void BoggleGraph_GetNeighborsFor_ReturnsNeighborsWhenThereAreSome()
        {
            BoggleGraph graph = new BoggleGraph();
            BoggleNode node = new BoggleNode(10, 10);
            Random rand = new Random();

            // first, give the node two neighbors
            BoggleNode neighbor1 = new BoggleNode(rand.Next(), rand.Next());
            BoggleNode neighbor2 = new BoggleNode(rand.Next(), rand.Next());
            graph.Add(new BoggleEdge(node, neighbor1))
                 .Add(new BoggleEdge(node, neighbor2));

            ISet<BoggleNode> neighbors = graph.GetNeighborsFor(node);
            Assert.IsTrue(neighbors.Count == 2);
            Assert.IsTrue(neighbors.Contains(neighbor1));
            Assert.IsTrue(neighbors.Contains(neighbor2));
        }
    }
}
