using System;

namespace LexerParser
{
    public class Expression : Node
    {
        public Node LeftNode { get; set; }
        public char Operator { get; set; }
        public Node RightNode { get; set; }


        public Expression(Node leftNode, char @operator, Node rightNode)
        {
            LeftNode = leftNode;
            Operator = @operator;
            RightNode = rightNode;
        }

    }
}