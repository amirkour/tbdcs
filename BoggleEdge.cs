using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boggle
{
    public class BoggleEdge
    {
        public BoggleNode VertexOne { get; set; }
        public BoggleNode VertexTwo { get; set; }

        public BoggleEdge() { this.VertexOne = null;  this.VertexTwo = null; }
        public BoggleEdge(BoggleNode one, BoggleNode two) { this.VertexOne = one;  this.VertexTwo = two; }

        protected bool BothAreNull(object a, object b)
        {
            return a == null && b == null;
        }
        protected bool ExactlyOneIsNull(object a, object b, out object theNonNullOne)
        {
            theNonNullOne = null;
            if(a == null && b != null)
            {
                theNonNullOne = b;
                return true;
            }
            else if(a != null && b == null)
            {
                theNonNullOne = a;
                return true;
            }

            return false;
        }


        public override bool Equals(object obj)
        {
            BoggleEdge other = obj as BoggleEdge;
            if (other == null)
                return false;

            object thisOne = this.VertexOne;
            object thisTwo = this.VertexTwo;
            object otherOne = other.VertexOne;
            object otherTwo = other.VertexTwo;
            object thisNonNullOne = null;  // gonne use this a few times in the coming logic ...
            object otherNonNullOne = null; // gonne use this a few times in the coming logic ...

            if (BothAreNull(thisOne, thisTwo))
            {
                if (BothAreNull(otherOne, otherTwo))
                    return true;
                else
                    return false;
            }
            else if(ExactlyOneIsNull(thisOne, thisTwo, out thisNonNullOne))
            {
                if (ExactlyOneIsNull(otherOne, otherTwo, out otherNonNullOne))
                    return thisNonNullOne.Equals(otherNonNullOne);
                else
                    return false;
            }

            // ok, this edge has two non-null vertices.
            // this edge'll only be equal to the other edge if it also has two non-null vertices:
            else if(!BothAreNull(otherOne,otherTwo))
            {
                // order doesn't matter for edge equality - if both edges have the same two vertices
                // in ANY order, they're considered equivalent
                return
                    (thisOne.Equals(otherOne) && thisTwo.Equals(otherTwo)) ||
                    (thisOne.Equals(otherTwo) && thisTwo.Equals(otherOne));
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            int code = 0;
            if (this.VertexOne != null) code ^= this.VertexOne.GetHashCode();
            if (this.VertexTwo != null) code ^= this.VertexTwo.GetHashCode();

            return code;
        }

        public override string ToString()
        {
            string str = "";
            if (this.VertexOne != null)
                str += this.VertexOne.ToString();
            else
                str += "<null>";

            if (this.VertexTwo != null)
                str += ", " + this.VertexTwo.ToString();
            else
                str += ", <null>";

            str = "(" + str + ")";
            return str;
        }
    }
}
