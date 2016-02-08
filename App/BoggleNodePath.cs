using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boggle;

namespace App
{
    /// <summary>
    /// A BoggleNodePath is an immutable list of boggle nodes - the paths are conceptually
    /// 'words' in a boggle game.  
    /// 
    /// For example, a path might be ['A', 'M', 'I', 'R'] - or
    /// in general, the BoggleNode objects corresponding to those letters.
    /// </summary>
    public class BoggleNodePath
    {
        public BoggleNode[] Path { get; }

        // a path of boggle nodes MUST start with something - no empty paths allowed
        private BoggleNodePath() { }
        public BoggleNodePath(BoggleNode initialNode)
        {
            if (initialNode == null) throw new Exception("Cannot start a boggle node path with null");
            Path = new BoggleNode[1];
            Path[0] = initialNode;
        }
        public BoggleNodePath(BoggleNode[] initPath)
        {
            if (initPath == null) throw new Exception("Cannot start a boggle node path with null");
            if(initPath.Length <= 0) throw new Exception("Cannot start a boggle node path with an empty previous path");
            this.Path = initPath;
        }

        public BoggleNode GetLastNode()
        {
            if (Path == null || Path.Length < 1) return null;
            return Path[Path.Length - 1];
        }
        public BoggleNode GetSecondToLastNode()
        {
            if (Path == null || Path.Length < 2) return null;
            return Path[Path.Length - 2];
        }
        public string AsString()
        {
            if (this.Path == null || this.Path.Length <= 0) return "";
            StringBuilder bldr = new StringBuilder();
            foreach (BoggleNode node in this.Path)
                bldr.Append(node.Character);

            return bldr.ToString();
        }
        public static BoggleNodePath Concat(BoggleNodePath path, BoggleNode toConcat)
        {
            if (path == null || toConcat == null) throw new Exception("Cannot concatenate null objects to boggle node paths");

            BoggleNode[] prevPath = path.Path;
            BoggleNodePath result = null;
            if (prevPath == null)
            {
                result = new BoggleNodePath(toConcat);
            }
            else
            {
                BoggleNode[] newPath = new BoggleNode[prevPath.Length + 1];
                for (int i = 0; i < prevPath.Length; i++)
                    newPath[i] = prevPath[i];

                newPath[newPath.Length - 1] = toConcat;
                result = new BoggleNodePath(newPath);
            }

            return result;
        }
    }
}
