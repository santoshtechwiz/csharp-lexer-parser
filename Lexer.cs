using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexerParser
{
    public class Lexer
    {

        private int _sourceLength;
        private bool _hasMore;
        private int _currentCursor = 0;

        private List<Token> _tokens;

        private char[] _chars;


        public Lexer(char[] chars)
        {
            _chars = chars;
            _sourceLength = chars.Length;
            _currentCursor = 0;
            _tokens = new List<Token>();
            _hasMore = true;


        }

        public Token Consume()
        {

            LookaheadInternal(1);
            if (_tokens.Count() == 0)
            {
                return Utility.EOL;
            }

            return _tokens.Remove();
        }

        public Token Lookahead(int i)
        {

            LookaheadInternal(i + 1);
            if (i >= _tokens.Count())
            {
                return Utility.EOL;
            }

            return _tokens[i];
        }

        private void LookaheadInternal(int i)
        {
            while (_hasMore && _tokens.Count() < i)
            {
                AddToken();
            }
        }

        private void AddToken()
        {
            if (_currentCursor >= _sourceLength)
            {
                _hasMore = false;
                return;
            }

            while (char.IsWhiteSpace(_chars[_currentCursor]))
            {

                _currentCursor++;

            }

            Token token = null;
            char lookaheadChar = _chars[_currentCursor];
            if (Utility.IsDigit(lookaheadChar))
            {
                StringBuilder sb = new StringBuilder();
                while (_currentCursor < _sourceLength && Utility.IsDigit(_chars[_currentCursor]))
                {
                    sb.Append(_chars[_currentCursor++]);
                }
                token = new Token(sb.ToString(), TokenType.Number);
            }
            else if (Utility.IsOperator(lookaheadChar))
            {
                token = new Token(_chars[_currentCursor++], TokenType.Operator);
            }
            else if (Utility.IsParenthesis(lookaheadChar))
            {
                token = new Token(_chars[_currentCursor++], TokenType.Operator);
            }
            else
            {
                throw new LexerException("unknown token");
            }
            _tokens.Add(token);

        }


    }
}