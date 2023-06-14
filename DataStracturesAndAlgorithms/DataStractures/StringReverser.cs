using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class StringReverser
    {
        public string Reverse(string input)
        {
            if (input == null) throw new Exception("your input is not valid.");
             
            Stack<char> stack = new Stack<char>();
            foreach (var item in input)
                stack.Push(item);

            var revers = new StringBuilder();
            while (stack.Count != 0)
                revers.Append(stack.Pop());

            return revers.ToString();
        }
    }
}

