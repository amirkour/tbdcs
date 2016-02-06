using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boggle
{
    public class BoggleGraph
    {
        protected List<BoggleNode> _nodes;
        protected List<BoggleEdge> _edges;

        public int NodeCount { get { return _nodes != null ? _nodes.Count : 0; } }
        public int EdgeCount { get { return _edges != null ? _edges.Count : 0; } }

        public bool Contains(BoggleNode node)
        {
            if (node == null || _nodes == null) return false;

            return _nodes.Contains(node);
        }

        public bool Contains(BoggleEdge edge)
        {
            if (_edges == null || edge == null) return false;

            return _edges.Contains(edge);
        }

        public BoggleGraph Add(BoggleNode node)
        {
            if (_nodes == null)
                _nodes = new List<BoggleNode>();

            if(node != null && !this.Contains(node))
                _nodes.Add(node);

            return this;
        }

        public BoggleGraph Add(BoggleEdge edge)
        {
            if (_edges == null)
                _edges = new List<BoggleEdge>();

            if (edge != null && !this.Contains(edge))
                _edges.Add(edge);

            this.Add(edge.VertexOne);
            this.Add(edge.VertexTwo);

            return this;
        }

        /// <summary>
        /// Helper that returns all neighbors of the given node in this graph,
        /// or an empty list if no neighbors exist for the given node, or
        /// if the node is null.
        /// </summary>
        public ISet<BoggleNode> GetNeighborsFor(BoggleNode node)
        {
            ISet<BoggleNode> neighbors = new HashSet<BoggleNode>();
            if (node == null) return neighbors;
            if (_edges.IsNullOrEmpty()) return neighbors;

            BoggleNode neighbor = null;
            foreach (BoggleEdge nextEdge in _edges)
            {
                if (nextEdge.Contains(node, out neighbor))
                    neighbors.Add(neighbor);
            }

            return neighbors;
        }

        public override bool Equals(object obj)
        {
            BoggleGraph other = obj as BoggleGraph;
            if (other == null) return false;
            
            if (other.NodeCount != this.NodeCount) return false;
            if (other.EdgeCount != this.EdgeCount) return false;

            if(_nodes != null)
            {
                foreach(BoggleNode node in _nodes)
                {
                    if (!other.Contains(node)) return false;
                }
            }
            if(_edges != null)
            {
                foreach(BoggleEdge edge in _edges)
                {
                    if (!other.Contains(edge)) return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int code = 0;
            if (!_nodes.IsNullOrEmpty())
            {
                foreach (BoggleNode node in _nodes)
                    code ^= node.GetHashCode();
            }
            if(!_edges.IsNullOrEmpty())
            {
                foreach (BoggleEdge edge in _edges)
                    code ^= edge.GetHashCode();
            }

            return code;
        }

        public override string ToString()
        {
            string str = "Nodes: ";
            if(!_nodes.IsNullOrEmpty())
            {
                foreach (BoggleNode node in _nodes)
                    str += node.ToString() + " ";
            }

            str += "Edges: ";
            if(!_edges.IsNullOrEmpty())
            {
                foreach (BoggleEdge edge in _edges)
                    str += edge.ToString() + " ";
            }

            return str;
        }
    }
}
