using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boggle
{
    public class BoggleNode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BoggleNode() { this.X = 0; this.Y = 0; }
        public BoggleNode(int x, int y) { this.X = x;  this.Y = y; }

        /// <summary>
        /// Helper that returns true if this node is immediately above
        /// the given node, false otherwise.
        /// </summary>
        public bool IsImmediatelyAbove(BoggleNode node)
        {
            if (node == null) return false;
            return this.Y == (node.Y - 1) && this.X == node.X;
        }

        /// <summary>
        /// Helper that returns true if this node is immediately below
        /// the given node, false otherwise.
        /// </summary>
        public bool IsImmediatelyBelow(BoggleNode node)
        {
            if (node == null) return false;
            return this.Y == (node.Y + 1) && this.X == node.X;
        }

        /// <summary>
        /// Helper that returns true if this node is immediately to
        /// the left of the given node, false otherwise.
        /// </summary>
        public bool IsImmediatelyLeftOf(BoggleNode node)
        {
            if (node == null) return false;
            return (this.X == node.X - 1) && (this.Y == node.Y);
        }

        /// <summary>
        /// Helper that returns true if this node is immediately to
        /// the right of the given node, false otherwise.
        /// </summary>
        public bool IsImmediatelyRightOf(BoggleNode node)
        {
            if (node == null) return false;
            return (this.X == node.X + 1) && (this.Y == node.Y);
        }

        public bool IsNeighborsWith(BoggleNode node)
        {
            if (node == null) return false;

            return false;
        }

        public override bool Equals(object obj)
        {
            BoggleNode other = obj as BoggleNode;
            if (other == null)
                return false;

            return other.X == this.X && other.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        public override string ToString()
        {
            return "{X: " + this.X + ", Y: " + this.Y + "}";
        }
    }
}
