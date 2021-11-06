using System;
using Lang.Analyzers;

namespace Lang
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = new Lexer("(3-4)*5l");
            var lexems = lexer.Lex();
            foreach(Token lexem in lexems)
                Console.Write($"{lexem.Type}: {lexem.Number} ");
        }
    }
}
