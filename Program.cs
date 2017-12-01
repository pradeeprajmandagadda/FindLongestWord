using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLongest
{
    class Program
    {
        public static string[] fi = System.IO.File.ReadAllLines("C:\\Users\\Pradeep\\Downloads\\NET Test 00.txt");
       //public static string[] vals = { "cat", "cats", "catsdogcats", "catxdogcatsrat", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
       //public static List<string> some = vals.OrderByDescending(word => word.Length).ToList();
        public static List<string> some = fi.OrderByDescending(word => word.Length).ToList();
        static void Main(string[] args)
        {
            List<string> newValues = new List<string>();
            foreach (var k in some)
            {
                //Console.WriteLine(k);
                if (checkVals(k))
                {
                    newValues.Add(k);
                }
            }
            Console.WriteLine("first longest word is: " + newValues[0]);
            Console.WriteLine("Second longest word is: " + newValues[1]);
            Console.WriteLine("Total words possible are: " + newValues.Count);
            Console.ReadLine();
        }
      public static bool moreCheck(string wrd)
        {
            var lis = splitWord(wrd);
            foreach(var k in lis)
            {
                if(some.Contains(k.Item1))
                {
                    if(some.Contains(k.Item2))
                    {
                        return true;
                    }
                    else
                    {
                      return  checkVals(wrd);
                    }
                }
            }
            return false;
        }
        public static bool checkVals(string maxWord)
        {
            if(maxWord.Length == 1)
            {
                if (some.Contains(maxWord))
                {
                    return true;
                }
                else
                    return false;
            }
            var listWords = splitWord(maxWord);
            foreach(var li in listWords)
            {
                if(some.Contains(li.Item1))
                {
                    if(moreCheck(li.Item2))
                    {
                        return true;
                    }
               
                }
            }
            return false;
           
        }
        public static List<Tuple<string,string>> splitWord(string word)
        {
            var output = new List<Tuple<string, string>>();
            if(word.Length !=1)
            {
                for(int i=0;i<word.Length;i++)
                {
                    output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
                }
            }
            return output;
        }
    }
}
