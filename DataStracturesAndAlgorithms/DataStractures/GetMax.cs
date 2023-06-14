using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class HackerRank
    {
        public List<int> GetMax(List<string> operations)
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
