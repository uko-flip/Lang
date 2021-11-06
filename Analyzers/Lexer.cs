using System.Collections.Generic;

namespace Lang.Analyzers
{
    public class Lexer
    {
        private char[] _input;
        private int _pointer;

        public Lexer(string input)
        {
            _input = input.ToCharArray();
            _pointer = 0;
        }

        public Token[] Lex()
        {
            var tokens = new List<Token>();
            while(true)
            {
                var symbol = CurrentSymbol();
                if(symbol == '\0')
                    break;
                var newToken = new Token(TokenType.NotLexed);
                switch(symbol)
                {
                    case '+':
                        newToken = new Token(TokenType.Plus);
                        break;
                    case '-':
                        newToken = new Token(TokenType.Minus);
                        break;
                    case '*':
                        newToken = new Token(TokenType.Multiply);
                        break;
                    case '/':
                        newToken = new Token(TokenType.Divide);
                        break;
                    default:
                        if(char.IsDigit(symbol))
                            newToken = new Token(TokenType.Number, LexNumber());
                        else
                            newToken = new Token(TokenType.NotLexed);
                        break;
                }
                tokens.Add(newToken);
                NextSymbol();
            }
            return tokens.ToArray();
        }

        private int LexNumber()
        {
            var number = 0;
            PreviousSymbol();
            while(true)
            {
                var newSymbol = NextSymbol();
                if(!char.IsDigit(newSymbol))
                {
                    // NextSymbol();
                    break;
                }
                var newNumber = int.Parse(newSymbol.ToString());
                number *= 10;
                number += newNumber;
            }
            PreviousSymbol();
            
            return number;
        }

        private void PreviousSymbol()
        {
            _pointer--;
        }

        private char CurrentSymbol()
        {
            if(_pointer >= _input.Length)
                return '\0';
            return _input[_pointer];
        }
        private char NextSymbol()
        {
            _pointer++;
            if(_pointer >= _input.Length)
                return '\0';
            return _input[_pointer];
        }
    }
}
