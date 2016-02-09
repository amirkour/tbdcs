using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dict.com.aonaware.services;
using Boggle;
namespace App
{
    public class Program
    {
        protected static DictService dictSvc = new DictService();
        
        // dictionary matching strategies
        protected const string DICTIONARY_STRATEGY_PREFIX = "prefix";
        protected const string DICTIONARY_STRATEGY_EXACT = "exact";

        // The Collaborative International Dictionary of English v.0.44
        protected const string DICTIONARY_ID_ENGLISH = "gcide";
        
        public static bool IsExactWord(string word)
        {
            if (String.IsNullOrEmpty(word)) return false;

            // i'm gonna exclude single-letter words
            if (word.Length <= 1) return false;

            WordDefinition definition = dictSvc.DefineInDict(DICTIONARY_ID_ENGLISH, word);
            return definition != null && definition.Definitions != null && definition.Definitions.Length > 0;
        }
        public static bool IsPrefix(string prefix)
        {
            if (String.IsNullOrEmpty(prefix)) return false;
            DictionaryWord[] words = dictSvc.MatchInDict(DICTIONARY_ID_ENGLISH, prefix, DICTIONARY_STRATEGY_PREFIX);
            return words != null && words.Length > 0;
        }

        public void RecursivelyFindAllWords(BoggleGraph graph, BoggleNodePath currentPath, Dictionary<BoggleNode, List<string>> allResults)
        {
            /*
            if (graph == null) return;
            if (currentPath == null) return;
            if (allResults == null) return;

            // try and pick out the last element of the current path, we'll recurse starting there
            BoggleNode lastNodeInPath = currentPath.GetLastNode();
            if (lastNodeInPath == null) return;

            // what's the word this path represents?  if it's an exact english word, we'll throw
            // it in the list of results!
            string currentWord = currentPath.AsString();
            if (string.IsNullOrEmpty(currentWord)) return;
            if (IsExactWord(currentWord))
            {
                if(!allResults.ContainsKey(currentPath.Path[0]))
                    allResults[currentPath.Path[0]] = new List<string>();
                
                allResults[currentPath.Path[0]].Add(currentWord);
            }

            // if the current word isn't a prefix to any other words, we can stop here
            // because we'll never encounter an english word from here on down
            if (!IsPrefix(currentWord)) return;

            // now get all the neighbors in the graph for the last letter in the path - we'll
            // recurse down the graph paths for each neighbor ...
            ISet<BoggleNode> neighbors = graph.GetNeighborsFor(lastNodeInPath);
            if (neighbors == null || neighbors.Count <= 0) return;

            // ... with one exception: don't traverse backwards in the currentPath.  IE: don't
            // traverse to the second-to-last element of currentPath (if it exists.)
            BoggleNode secondToLastNodeInPath = currentPath.GetSecondToLastNode();

            foreach (BoggleNode neighbor in neighbors)
            {
                if (secondToLastNodeInPath != null && secondToLastNodeInPath.Equals(neighbor)) continue;
                RecursivelyFindAllWords(graph, BoggleNodePath.Concat(currentPath, neighbor), allResults);
            }
            */
        }
        public int GetRowAndColCountFromUser()
        {
            return 3;//todo
        }
        public char[][] GetCharArrayFromUser()
        {
            int rowAndColCount = GetRowAndColCountFromUser();

            char[][] array = new char[rowAndColCount][];
            for (int i = 0; i < rowAndColCount; i++)
                array[i] = new char[rowAndColCount];

            Console.WriteLine("");
            Console.WriteLine("Graph will be " + rowAndColCount + " x " + rowAndColCount + " ...");
            Console.WriteLine("");

            int done = 0;
            do
            {
                Console.WriteLine("Enter characters for row " + (done + 1) + " (must enter exactly " + rowAndColCount + " letters): ");
                string input = Console.ReadLine();
                Console.WriteLine("");

                if (input.Length != rowAndColCount)
                {
                    Console.WriteLine("You must enter exactly " + rowAndColCount + " characters!");
                    continue;
                }

                if(Regex.IsMatch(input, "[^abcdefghijklmnopqrstuvwxyz]", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Only letters are allowed!");
                    continue;
                }
                
                for(int i = 0; i < rowAndColCount; i++)
                    array[done][i] = input[i];

                done++;
                Console.WriteLine("Got it!");
                Console.WriteLine("");

            } while (done < rowAndColCount);

            return array;
        }

        public BoggleGraph CreateGraphFor(char[][] charArray)
        {
            /*
            BoggleGraph graph = new BoggleGraph();
            int cols = charArray[0].Length;
            int rows = charArray.Length;
            BoggleNode rowPrev = null;
            BoggleNode colPrev = null;

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if (i > 0)
                    {
                        rowPrev = new BoggleNode(j, i - 1, charArray[i - 1][j]);
                        if (!graph.Contains(rowPrev)) throw new Exception("The graph should have this node: " + rowPrev.ToString());
                    }
                    if (j > 0)
                    {
                        colPrev = new BoggleNode(j - 1, i, charArray[i][j - 1]);
                        if (!graph.Contains(colPrev)) throw new Exception("The graph should have this node: " + colPrev.ToString());
                    }
                }
            }

            return graph;
            */
            return null; // todo
        }

        public void Test()
        {
            char[][] charArray = GetCharArrayFromUser();
            for (int i = 0; i < charArray[0].Length; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < charArray.Length; j++)
                    Console.Write(charArray[i][j] + " ");

                Console.WriteLine("]");
            }

            /*
            BoggleGraph graph = new BoggleGraph();

            BoggleNode one = new BoggleNode() { X = 0, Y = 0, Character = 'A' };
            BoggleNode two = new BoggleNode() { X = 1, Y = 0, Character = 'L' };
            BoggleNode three = new BoggleNode() { X = 2, Y = 0, Character = 'L' };
            graph.Add(new BoggleEdge()
            {
                VertexOne = one,
                VertexTwo = two
            }).Add(new BoggleEdge()
            {
                VertexOne = two,
                VertexTwo = three
            });

            Dictionary<BoggleNode, List<string>> results = new Dictionary<BoggleNode, List<string>>();
            foreach (BoggleNode nextGraphNode in graph.Nodes)
            {
                BoggleNodePath startingPath = new BoggleNodePath(nextGraphNode);
                RecursivelyFindAllWords(graph, startingPath, results);
            }

            foreach(KeyValuePair<BoggleNode,List<string>> result in results)
            {
                Console.WriteLine(result.Key.ToString());
                foreach (String str in result.Value)
                    Console.WriteLine("  - " + str);
            }
            */
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Test();

            /*
            DictService svc = new DictService();
            //Dictionary[] dics = svc.DictionaryList();
            DictionaryWord[] words = svc.MatchInDict("gcide", "hell", "prefix");
            WordDefinition wd = svc.DefineInDict("gcide", "zxcvzxvc");

            Strategy[] strats = svc.StrategyList();
            foreach(DictionaryWord dw in words)
            {
                Console.WriteLine("hi there");
//Id  "gcide" string
//Name    "The Collaborative International Dictionary of English v.0.44"  string
//idField "gcide" string
//nameField   "The Collaborative International Dictionary of English v.0.44"  string

            }*/
        }
    }
}
