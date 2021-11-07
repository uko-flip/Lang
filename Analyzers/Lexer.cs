using System;
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
                Token token;
                token = GenerateToken();
                tokens.Add(token);
                if(token.Type == TokenType.EndOfFile)
                    break;
                NextSymbol();
            }
            return tokens.ToArray();
        }

        private Token GenerateToken()
        {
            char symbol = CurrentSymbol();
            if (symbol == '\0')
                return new Token(TokenType.EndOfFile);
            switch (symbol)
            {
                case '+':
                    return new Token(TokenType.Plus);
                case '-':
                    return new Token(TokenType.Minus);
                case '*':
                    return new Token(TokenType.Multiply);
                case '/':
                    return new Token(TokenType.Divide);
                case '(':
                    return new Token(TokenType.Lparen);
                case ')':
                    return new Token(TokenType.Rparen);
                default:
                    if (char.IsDigit(symbol))
                        return LexNumber();
                    return new Token(TokenType.NotLexed);
            }
        }

        private Token LexNumber()
        {
            var firstChar = CurrentSymbol();
            if(!char.IsDigit(firstChar))
                throw new Exception("Char not digit.");
            var resultString = "";
            do {
                var currentChar = CurrentSymbol();
                if(!char.IsDigit(currentChar))
                    break;
                resultString += currentChar.ToString();
            } while(char.IsDigit(NextSymbol()));
            var resultNumber = int.Parse(resultString);
            PreviousSymbol();
            return new Token(TokenType.Number, resultNumber);
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
