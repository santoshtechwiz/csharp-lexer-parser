using System;

namespace LexerParser
{
    public class Number : Node
    {

        public int Num { get; set; }

        public Number(int num)
        {
            Num = num;
        }


        public override String ToString() => Num.ToString();
    }
}