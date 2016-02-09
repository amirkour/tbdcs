using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boggle
{
    public class BoggleGraph
    {
        protected BoggleNode[][] _graph;
        public BoggleNode[][] Graph { get { return _graph; } }

        public BoggleGraph() { }
        public BoggleGraph(int cols, int rows)
        {
            _graph = new BoggleNode[cols][];
            for (int i = 0; i < cols; i++)
                _graph[i] = new BoggleNode[rows];
        }
        public BoggleGraph(BoggleNode[][] newGraph)
        {
            _graph = newGraph;
        }

        /// <summary>
        /// Helper that determines if the given x,y coords are in-bounds for this graph.
        /// Returns true and populates the given output-node if so, false/null otherwise.
        /// </summary>
        public bool InBounds(int x, int y, out BoggleNode node)
        {
            node = null;
            if (_graph == null) return false;
            if (x < 0 || y < 0) return false;
            if (x >= _graph.Length) return false;

            BoggleNode[] row = _graph[x];
            if (y >= row.Length) return false;

            node = row[y];
            return true;
        }

        /// <summary>
        /// Helper that returns all neighbors of the given node in this graph,
        /// or an empty list if no neighbors exist for the given node, or
        /// if the node is null.
        /// </summary>
        public ISet<BoggleNode> GetNeighborsFor(int x, int y)
        {
            ISet<BoggleNode> neighbors = new HashSet<BoggleNode>();
            BoggleNode nextNode = null;
            if (!this.InBounds(x, y, out nextNode)) return neighbors;
            
            // top:
            if (InBounds(x, y - 1, out nextNode)) neighbors.Add(nextNode);

            // left:
            if (InBounds(x - 1, y, out nextNode)) neighbors.Add(nextNode);

            // bottom:
            if (InBounds(x, y + 1, out nextNode)) neighbors.Add(nextNode);

            // right
            if (InBounds(x + 1, y, out nextNode)) neighbors.Add(nextNode);

            return neighbors;
        }

        public override bool Equals(object obj)
        {
            BoggleGraph other = obj as BoggleGraph;
            if (other == null) return false;

            if (_graph == null && other.Graph == null)
                return true;

            if ((_graph == null && other.Graph != null) ||
                (_graph != null && other.Graph == null))
                return false;

            BoggleNode[][] thisGraph = _graph;
            BoggleNode[][] otherGraph = other.Graph;
            if (thisGraph.Length != otherGraph.Length) return false;

            // they have equal length, but if the array has length 0 then just stop now
            if (thisGraph.Length <= 0) return true;
            
            for(int i = 0; i < thisGraph.Length; i++)
            {
                if (thisGraph[i].Length != otherGraph[i].Length) return false;
                for(int j = 0; j < this.Graph[0].Length; j++)
                {
                    if (!thisGraph[i][j].Equals(otherGraph[i][j])) return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int code = 0;
            if(_graph != null)
            {
                for(int i = 0; i < _graph.Length; i++)
                {
                    for(int j = 0; j < _graph[i].Length; j++)
                    {
                        code ^= _graph[i][j].GetHashCode();
                    }
                }
            }

            return code;
        }

        public override string ToString()
        {
            StringBuilder bldr = new StringBuilder();
            if(_graph != null)
            {
                for(int i = 0; i < _graph.Length; i++)
                {
                    bldr.Append("[");
                    for(int j = 0; j < _graph[i].Length; j++)
                    {
                        bldr.Append(_graph[i][j].ToString());
                        bldr.Append(",");
                    }
                    bldr.Append("]");
                }
            }

            return "Graph: {" + bldr.ToString() + "}";
        }
    }
}
