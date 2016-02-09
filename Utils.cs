using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boggle
{
    public static class Utils
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count <= 0;
        }

        public static char GetRandomCharacter()
        {
            Random rand = new Random();
            int letter = rand.Next() % 26;
            char toRet = ' ';
            switch (letter)
            {
                case 0: toRet = 'a'; break;
                case 1: toRet = 'b'; break;
                case 2: toRet = 'c'; break;
                case 3: toRet = 'd'; break;
                case 4: toRet = 'e'; break;
                case 5: toRet = 'f'; break;
                case 6: toRet = 'g'; break;
                case 7: toRet = 'h'; break;
                case 8: toRet = 'i'; break;
                case 9: toRet = 'j'; break;
                case 10: toRet = 'k'; break;
                case 11: toRet = 'l'; break;
                case 12: toRet = 'm'; break;
                case 13: toRet = 'n'; break;
                case 14: toRet = 'o'; break;
                case 15: toRet = 'p'; break;
                case 16: toRet = 'q'; break;
                case 17: toRet = 'r'; break;
                case 18: toRet = 's'; break;
                case 19: toRet = 't'; break;
                case 20: toRet = 'u'; break;
                case 21: toRet = 'v'; break;
                case 22: toRet = 'w'; break;
                case 23: toRet = 'x'; break;
                case 24: toRet = 'y'; break;
                case 25: toRet = 'z'; break;
                default: toRet = 'z'; break;
            }

            return toRet;
        }
        public static BoggleGraph BuildRandomGraph(int cols, int rows)
        {
            if (cols < 0 || rows < 0) throw new Exception("Can't build a graph for negative cols/rows");

            BoggleGraph graph = new BoggleGraph(cols, rows);
            for(int i = 0; i < graph.Graph.Length; i++)
            {
                for(int j = 0; j < graph.Graph[i].Length; j++)
                {
                    graph.Graph[i][j] = new BoggleNode(i, j, GetRandomCharacter());
                }
            }

            return graph;
        }
    }
}
