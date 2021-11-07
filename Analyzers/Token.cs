namespace Lang.Analyzers
{
    public enum TokenType
    {
        NotLexed,
        EndOfFile,
        
        Number,
        StringLiteral,

        Plus,
        Minus,
        Multiply,
        Divide,

        Lparen,
        Rparen

    }

    public class Token
    {
        public object Value { get; private set; }
        public TokenType Type { get; private set; }

        public Token(TokenType type, object value = null)
        {
            Value = value;
            Type = type;
        }
    }
}