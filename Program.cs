using System;
using Lang.Analyzers;

namespace Lang
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var lexems = new Lexer(expression).Lex();
            foreach(Token token in lexems)
            {
                Console.Write($" {token.Type}");
                if(token.Type == TokenType.Number)
                    Console.Write($"({token.Number})");
            }

        }
    }
}
