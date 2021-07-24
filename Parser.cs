using System;


/*
	expr  :term
		| expr ('+' |'-') term;
	 term:factor
		 |factor ('*'|'/') term;

	factor:NUMBER;
    
*/

namespace LexerParser
{
    public class Parser
    {

        private Lexer lexer;
        private Token currentToken;
        public Parser(String source)
        {

            var charArray = source.Trim(' ').ToCharArray();
            lexer = new Lexer(charArray);
            currentToken = lexer.Lookahead(0);
        }

        public Node Expr()
        {
            var node = Term();
            while ((IsToken("+") || IsToken("-")))
            {
                var @operator = lexer.Consume().Value;
                var right = this.Term();
                node = new Expression(node, @operator[0], right);
            }


            return node;
        }

        public Node Term()
        {
            var node = Factor();

            while (IsToken("*") || IsToken("/"))
            {
                var @operator = lexer.Consume().Value; // read *//
                var right = this.Factor();
                node = new Expression(node, @operator[0], right);

            }
            return node;

        }

        public Node Factor()
        {
            if (IsToken("("))
            {
                lexer.Consume();
                var exp = Expr();
                lexer.Consume();
                return exp;
            }
            else
            {
                var token = lexer.Consume();
                if (token.Type == TokenType.Number)
                {
                    var val = int.Parse(token.Value);
                    return new Number(val);
                }
                else
                {
                    throw new LexerException("Invalid Token");
                }
            }
        }

        public bool IsToken(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var token = lexer.Lookahead(0);
            var isMatch = token.Value.Trim().Equals(name.Trim());
            return token.Type == TokenType.Operator && isMatch;
        }
    }
}