using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe responsável por armazenar os dados do token.
    /// </summary>
    class Token
    {
        public TokenType.Type Type;
        public string Lexema;
        public Position Position;

        /// <summary>
        /// Método construtor da classe.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lexema"></param>
        /// <param name="position"></param>
        public Token(TokenType.Type type, string lexema, Position position)
        {
            Type = type;
            Lexema = lexema;
            Position = position;
        }

        /// <summary>
        /// Método responsável por retornar o objeto como string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Type + " - " + Lexema + " - " + Position.ToString();
        }
    }
}
