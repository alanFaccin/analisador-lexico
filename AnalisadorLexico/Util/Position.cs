using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe reponsável por representar a posição do token no código.
    /// </summary>
    class Position
    {
        public int Line;
        public int Column;

        /// <summary>
        /// Método construtor da classe.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        /// <summary>
        /// Método responsável por retornar o objeto como string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Linha: " + Line + " Coluna: " + Column;
        }
    }
}
