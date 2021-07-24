namespace LexerParser
{

    public enum TokenType
    {
		Number=1,
		Operator=2
    }
    public class Token
	{
		public string Value { get; set; }
		public TokenType Type { get; set; } 

		public Token(string value, TokenType type)
		{
			Value = value;
			Type = type;
		}

		public Token(char ch, TokenType type)
		{
			Value = ch.ToString();
			Type = type;
		}


		public override string ToString()
		{
			return $"[Token value==>{Value} type==>{Type}]";
		}
	}

}
