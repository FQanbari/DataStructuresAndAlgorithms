using System.Collections.Generic;

namespace DataStructures
{
    public class Expression
    {
        private string exp;
        private static List<char> rightBrackets = new List<char> { ')', '}', ']', '>' };
        private static List<char> leftBrackets = new List<char> { '(', '{', '[', '<' };
        public Expression(string exp)
        {
            this.exp = exp;
        }
        public bool IsBalanced()
        {
            exp = exp.Trim();
            var stack = new Stack<char>();
            foreach (var ch in exp)
            {
                if (IsLeftBracket(ch))
                    stack.Push(ch);

                if (IsRightBracket(ch))
                {
                    if (stack.Count == 0) return false;
                    var top = stack.Pop();
                    if (IsBracketsMatch(top,ch))
                        return false;
                }                    
            }

            return stack.Count == 0;
        }
        private bool IsLeftBracket(char ch)
        {                        
            return leftBrackets.Contains(ch);
        }
        private bool IsRightBracket(char ch)
        {            
            return rightBrackets.Contains(ch);
        }
        private bool IsBracketsMatch(char left,char right)
        {
            return leftBrackets.IndexOf(left) != rightBrackets.IndexOf(right);
        }
    }
}

