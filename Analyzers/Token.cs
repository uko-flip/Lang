namespace Lang.Analyzers
{
    public enum TokenType
    {
        NotLexed,
        EndOfFile,
        
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,

        Lparen,
        Rparen

    }

    public class Token
    {
        public int Number { get; private set; }
        public TokenType Type { get; private set; }

        public Token(TokenType type, int number = 0)
        {
            Number = number;
            Type = type;
        }
    }
}