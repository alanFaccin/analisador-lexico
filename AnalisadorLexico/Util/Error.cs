using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe responsável por representar os erros.
    /// </summary>
    class Error
    {
        public ErrorType ErrorType { get; set; }
        public string Message { get; set; }
        public Position Position { get; set; }

        /// <summary>
        /// Método construtor da classe.
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="message"></param>
        /// <param name="position"></param>
        public Error(ErrorType errorType, string message, Position position)
        {
            ErrorType = errorType;
            Message = message;
            Position = position;
        }

        /// <summary>
        /// Método responsável por retornar o objeto como string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("ErrorType: ");
            str.Append(ErrorType.ToString());
            str.Append(" Message: ");
            str.Append(Message);
            str.Append(" Position: ");
            str.Append(Position.ToString());

            return str.ToString();
        }
    }
}
