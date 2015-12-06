using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe responsável por representar os tipos de erros.
    /// </summary>
    class ErrorType
    {
        public const int DANGER = 1;
        public const int WARNING = 2;
        public const int INFO = 3;

        public int Level { get; set; }

        /// <summary>
        /// Método construtor da classe.
        /// </summary>
        /// <param name="level"></param>
        public ErrorType(int level)
        {
            Level = level;
        }

        /// <summary>
        /// Método responsável por retornar o objeto como string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";

            switch (Level)
            {
                case DANGER:
                    str = "DANGER";
                    break;
                case WARNING:
                    str = "WARNING";
                    break;
                case INFO:
                    str = "INFO";
                    break;
            }

            return str;
        }

    }
}
