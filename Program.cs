/*Given two strings s and t, return true if t is an anagram of s, and false otherwise.
 *An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
 *Example 1:
    *Input: s = "anagram", t = "nagaram"
    *Output: true
 *Example 2:
    *Input: s = "rat", t = "car"
    *Output: false
*/

namespace CCAD16_Assignment7_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ANAGRAM PROGRAM");
            Console.WriteLine("\nEnter your first string:");
            string s = Console.ReadLine();

            Console.WriteLine("\nEnter your second string:");
            string t = Console.ReadLine();

            bool result = IsAnagram(s, t);

            Console.WriteLine($"The two strings are anagrams: {result}");
        }

        static bool IsAnagram(string s, string t)
        {
            //Edge case
            if (s.Length != t.Length)
            {
                return false;
            }

            //new dictionary
            Dictionary<char, int> letterCount = new Dictionary<char, int>();

            //iterate chars in 1st string
            foreach (char c in s)
            {
                if (letterCount.ContainsKey(c))
                {
                    letterCount[c]++;
                }
                else
                {
                    letterCount[c] = 1;
                }
            }

            // Subtract character counts based on the second string
            foreach (char c in t)
            {
                if (!letterCount.ContainsKey(c))
                {
                    return false; // If a character does not exist in the dictionary
                }

                letterCount[c]--;

                if (letterCount[c] < 0)
                {
                    return false; // More occurrences of the letter in t than in s
                }
            }

            // If the dictionary is balanced (all counts zero), it's an anagram
            return true;
        }
    }
}
