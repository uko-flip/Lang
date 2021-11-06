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
        Divide

    }

    public class Token
    {
        private readonly int _number;
        private readonly TokenType _type;

        public Token(TokenType type, int number = 0)
        {
            _number = number;
            _type = type;
        }

        public int Number
        {
            get
            {
                return _number;
            } 
        }
        public TokenType Type
        {
            get
            {
                return _type;
            } 
        }
    }
}