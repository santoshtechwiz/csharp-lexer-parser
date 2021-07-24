using System;

namespace LexerParser
{
    public class LexerException : Exception
    {
        public LexerException(string syntaxError):base(syntaxError)
        {
            
        }
    }
}