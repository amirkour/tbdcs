using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dict.com.aonaware.services;
namespace App
{
    public class Program
    {
        // dictionary matching strategies
        const string DICTIONARY_STRATEGY_PREFIX = "prefix";
        const string DICTIONARY_STRATEGY_EXACT = "exact";

        // The Collaborative International Dictionary of English v.0.44
        const string DICTIONARY_ID_ENGLISH = "gcide";

        public static void Main(string[] args)
        {
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

            }
        }
    }
}
