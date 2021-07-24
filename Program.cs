using System;
using Newtonsoft.Json;

namespace LexerParser
{
    public class Program

    {
        public static int Evaluate(Node ast)
        {
            if (ast is Number)
            {
                return ((Number)ast).Num;
            }
            else if (ast is Expression)
            {
                Expression exp = (Expression)ast;
                int left = Evaluate(exp.LeftNode);
                int right = Evaluate(exp.RightNode);

                switch (exp.Operator)
                {
                    case '+':
                        return left + right;
                    case '-':
                        return left - right;
                    case '*':
                        return left * right;
                    case '/':
                        return left / right;
                    default:
                        throw new Exception("unknown operator");
                }
            }
            else
            {
                throw new Exception("don't support eval " + ast);
            }
        }

        public static void Main(String[] args)
        {

            var source = "12+10/5";
            var lexer = new Lexer(source.ToCharArray());


            var token = lexer.Consume();
            while (token != Utility.EOL)
            {
                Console.WriteLine("=> " + token);
                Console.WriteLine("Next Token => " + lexer.Lookahead(0));
                token = lexer.Consume();
            }
            var parser = new Parser(source);
            var ast = parser.Expr();
            int result = Evaluate(ast);
            Console.WriteLine(JsonConvert.SerializeObject(ast));

            Console.WriteLine("Result:" + result);
        }




    }
}