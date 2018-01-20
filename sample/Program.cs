using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace codesample
{

   public class SampleProgram
      { 
             public static string FindLongestWords(string[] listOfWords)
              {
                  if (listOfWords == null) throw new ArgumentException("All the words");
                  var sortedWords = listOfWords.OrderByDescending(word => word.Length).ToList();
                  var dicect = new HashSet<String>(sortedWords);
                  foreach (var word in sortedWords)
                  {
                      if (isMadeOfWords(word, dicect))
                      {
                          return word;
                      }
                  }
                  return null;
              }

              private static bool isMadeOfWords(string word, HashSet<string> dict)
              {
                  if (String.IsNullOrEmpty(word)) return false;
                  if (word.Length == 1)
                  {
                      if (dict.Contains(word)) return true;
                      else return false;
                  }
                  foreach (var pair in generatePairs(word))
                  {
                      if (dict.Contains(pair.Item1))
                      {
                          if (dict.Contains(pair.Item2))
                          {
                              return true;
                          }
                          else
                          {
                              return isMadeOfWords(pair.Item2, dict);
                          }
                      }
                  }
                  return false;
              }

              private static List<Tuple<string, string>> generatePairs(string word)
              {
                  var output = new List<Tuple<string, string>>();
                  for (int i = 1; i < word.Length; i++)
                  {
                      output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
                  }
                  return output;
              }

              public static void Main(string[] args)
              {
              string[] listOfWords = File.ReadAllLines(@"~sample\Files\wordlist.txt");
              string longest = FindLongestWords(listOfWords);
              Console.WriteLine(longest);
            
            
            //display all the words in the Text file.
              foreach (string s in listOfWords)
              {
                  Console.WriteLine(s);
              }

               Console.WriteLine("Longest word from the list : {0}",
            FindLongestWords(listOfWords));
              Console.ReadKey();
              }
          }
}

