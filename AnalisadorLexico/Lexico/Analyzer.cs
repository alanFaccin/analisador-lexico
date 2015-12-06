using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AnalisadorLexico.Util;

namespace AnalisadorLexico.Lexico
{
    /// <summary>
    /// Classe responsável pelo analisador léxico(Regex).
    /// </summary>
    class Analyzer
    {
        /// <summary>
        /// Método resposável por realizar a análise léxica(Regex).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IList<Token> Analyze(string input)
        {

            IList<Token> listTokens = new List<Token>();

            string[] spl = Regex.Split(@input, "\\n");

            TokenType.Type TokenIds;

            for (int i = 0; i < spl.Length; i++)
            {
                string valueIndex = spl.ElementAt(i);

                MatchCollection MatchEs = Regex.Matches(valueIndex, @Regexp.StringPattern());

                foreach (Match val in MatchEs)
                {
                    string value = val.ToString();

                    Symbol Symbol = new Symbol();

                    ErrorType ErrorType = new ErrorType(ErrorType.WARNING);

                    Position pos = new Position(i + 1, val.Index);

                    if (Symbol.listSymbols.ContainsKey(value))
                    {
                        TokenIds = Symbol.listSymbols[value];

                        Token Token = new Token(TokenIds, value, pos);
                        listTokens.Add(Token);
                    }
                    else
                    {
                        if (Regex.IsMatch(value, Regexp.NUMBER))
                        {
                            TokenIds = TokenType.Type.NUMERO;
                            Token Token = new Token(TokenIds, value, pos);
                            listTokens.Add(Token);
                        }
                        else if (Regex.IsMatch(value, Regexp.COMMENT))
                        {
                            TokenIds = TokenType.Type.COMENTARIO;
                            Token Token = new Token(TokenIds, value, pos);
                            listTokens.Add(Token);
                        }
                        else if (Regex.IsMatch(value, Regexp.VARIABLE))
                        {
                            value = value.Replace('=', ' ');
                            TokenIds = TokenType.Type.VARIAVEL;
                            Token Token = new Token(TokenIds, value, pos);
                            TokenIds = TokenType.Type.ATRIBUICAO;
                            Token Token2 = new Token(TokenIds, "=", pos);
                            listTokens.Add(Token);
                            listTokens.Add(Token2);
                        }
                        else if (Regex.IsMatch(value, Regexp.TYPE_STRING))
                        {
                            value = value.Replace('"', ' ');
                            TokenIds = TokenType.Type.STRING;
                            Token Token = new Token(TokenIds, value, pos);
                            listTokens.Add(Token);
                        }
                    }
                }
            }

            return listTokens;
        }
    }
}
