﻿using System;
using System.Collections.Generic;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //var str = new List<string> { "1 83", "3", "2", "1 76" };
            var str = new List<string> { "1 1", "1 44", "3", "3", "2", "3", "3", "1 3", "1 37", "2", "3", "1 29", "3", "1 73", "1 51", "3", "3", "3", "1 70" };
            var result = GetMax(str);
            var result1 = getMax1(str);
            var result2 = getMax2(str);

        }
        public static List<int> GetMax(List<string> operations)
        {
            var result = new Stack<int>();
            var result1 = new List<int>();
            var pointer = 0;
            //var stack = new Stack<int>();
            var maxstack = 0;
            foreach (var item in operations)
            {
                var op = item.Split(' ');
                if (op[0] == "1")
                {
                    var tmp = Convert.ToInt32(op[1]);
                    if (result.Count == 0)
                        result.Push(tmp);
                    else
                    {
                        maxstack = result.Peek();
                        result.Push((tmp > maxstack) ? tmp : maxstack);
                    }

                }

                else if (op[0] == "2")
                    result.Pop();
                else if (op[0] == "3")
                {
                    result1.Add(result.Peek());
                }
            }
            return result1;
        }
    }

}

