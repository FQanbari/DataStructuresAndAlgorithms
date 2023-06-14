//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructures
{
    public class StringUtils
    {
        public static int countVowels(string str)
        {
            if (str == null)
                return 0;

            var count = 0;
            var vowels = "aeoui";
            foreach (var ch in str.ToLower())
                if (vowels.IndexOf(ch) != -1)
                    count++;

            return count;
        }
        public static string reverse(string str)
        {
            if (str == null)
                return "";

            var stringBuilder = new StringBuilder();
            for (var i =str.Length - 1;i >= 0;i--)
                stringBuilder.Append(str[i]);

            return stringBuilder.ToString();
        }
        public static string reverseWords(string str)
        {
            if (str == null)
                return "";

            var split = str.Split(" ");
            var reverseString = new StringBuilder();
            for (var i = split.Length - 1; i >= 0 ; i--)
                reverseString.Append( split[i] + " ");                         

            return reverseString.ToString().Trim();
        }
        public static bool areRotation(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            return (str1.Length == str2.Length && ((str1 + str1).Contains(str2)));
        }
        public static string removeDuplicates(string str)
        {
            if (str == null)
                return "";

            var output = new StringBuilder();
            var seen = new HashSet<char>();

            foreach(var ch in str)
            {
                if (!seen.Contains(ch))
                {
                    seen.Add(ch);
                    output.Append(ch);
                }
            }

            return output.ToString();
        }
        public static char getMaxOccuringChar(string str)
        {
            if (str == null || str.Length == 0)
                return '\0';

            const int ASCII_SIZE = 256;
            int[] frequencies = new int[ASCII_SIZE];

            foreach (var ch in str)
                frequencies[ch]++;

            int max = 0;
            char result = '\0';

            for(var i = 0;i < frequencies.Length; i++)
                if(frequencies[i] > max)
                {
                    max = frequencies[i];
                    result = (char)i;
                }

            return result;
            //if (str == null)
            //    return '\0';

            //if (str.Length == 0)
            //    return '\0';

            //var output = new Dictionary<char,int>();
            //var t = output.Keys;
            //foreach (var ch in str)
            //{
            //    var count = (output.ContainsKey(ch)) ? (int)output[ch] : 0;
            //    if (count == 0)
            //        output.Add(ch, count + 1);
            //    else
            //        output[ch] = count + 1;
            //}

            //var max = (int)output[str[0]];
            //var index = 0;
            //for (int i = 1; i < str.Length; i++)
            //{
            //    if ((int)output[str[i]] > max)
            //    {
            //        max = (int)output[str[i]];
            //        index = i;
            //    }
            //}

            //return str[index];
        }
        public static string capitalize(string str)
        {
            if (str == null || str.Length == 0)
                return null;

            var output = new StringBuilder();
            foreach(var word in str.Trim().Replace(@"/\s\s+/g", " ").Split(" "))
            {
                if (word.Length == 0)
                    continue;

                output.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ");
            }

            return output.ToString().Trim();
        }
        public static bool areAnagram(string first,string second)
        {
            if (first == null || second == null || first.Length != second.Length)
                return false;

            var f = first.ToCharArray().ToList();
            f.Sort();
            var s = second.ToCharArray().ToList();
            s.Sort();
            return f.SequenceEqual(s);
        }
        public static bool areAnagram2(string first, string second)
        {
            if (first == null || second == null)
                return false;

            const int ENGLISH_ALAPHABET = 26;
            int[] frequencies = new int[ENGLISH_ALAPHABET];

            first = first.ToLower();
            for (var i = 0; i < first.Length; i++)
                frequencies[first[i] - 'a']++;

            second = second.ToLower();
            for (var i = 0; i < second.Length; i++)
            {
                var index = second[i] - 'a';
                if (frequencies[index] == 0)
                    return false;

                frequencies[index]--;
            }

            return true;
        }
        public static bool isPalindrome(string str)
        {
            if (str == null)
                return false;

            var left = 0;
            var right = str.Length - 1;

            while (left < right)
                if (str[left++] != str[right--]) 
                    return false;

            return true;
        }
    }
}

