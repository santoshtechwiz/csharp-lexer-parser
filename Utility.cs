using System.Collections.Generic;

namespace LexerParser
{
    public static class Utility
    {
        public static Token EOL = new Token("EOL", 0);
        public static bool IsDigit(char ch)
        {
            return '0' <= ch && ch <= '9';

        }

        public static bool IsSpace(char ch)
        {
            return ch==' ';
        }

        public static bool IsOperator(char ch)
        {
            return (ch == '+' || ch == '-' || ch == '*' || ch == '/');
        }

        public static bool IsParenthesis(char ch)
        {
            return ch == '(' || ch == ')';
        }
        public static Token Remove(this List<Token> tokens){
            var currentToken=tokens[0];
            tokens.RemoveAt(0);
            return currentToken;
            
        }
    }
}
