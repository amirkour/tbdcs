using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boggle;

namespace App
{
    /// <summary>
    /// A BoggleNodResult object represents a node in a boggle graph and all the words
    /// that originate from that node (or an empty list if there are none.)
    /// </summary>
    public class BoggleNodeResult
    {
        public BoggleNode Node { get; set; }
        public List<string> Words { get; set; }
        public override string ToString()
        {
            StringBuilder bldr = new StringBuilder();
            bldr.Append("{ Node: ");
            if (this.Node == null)
                bldr.Append("<none>");
            else
                bldr.Append(this.Node.ToString());

            bldr.Append(" Words: [");
            if(!this.Words.IsNullOrEmpty())
            {
                foreach (String str in this.Words)
                    bldr.Append(" " + str);
            }
            bldr.Append(" ]");
            return bldr.ToString();
        }
    }
}
