using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe responsável por armazenar as expressões regulares.
    /// </summary>
    class Regexp
    {
        public const string NUMBER = "[0-9]+";
        public const string STRING = "[a-zA-Z]+";
        public const string TYPE_STRING = "(\"\\w+\")";
        public const string BINARYOP = "[\\+\\-\\*]";
        public const string WRITESPACE = "\t\f\r\n";
        public const string COMPARISION = "(>=)|(<=)|(==)|(=)|(<>)|(>)|(<)";
        public const string COMMENT = "^\\/\\/[a-zA-Z0-9á-úÁ-Ú ]+";
        public const string OPEN_BRACES = "[{]";
        public const string CLOSE_BRACES = "[}]";
        public const string OPEN_PARENTHESES = "[(]";
        public const string CLOSE_PARENTHESES = "[)]";
        public const string END_COMMAND = "[;]";
        public const string INCREMENT = "(\\+\\+)";
        public const string DECREMENT = "(\\-\\-)";
        public const string VARIABLE = "[a-zA-Z]{1,}\\s?=";

        /// <summary>
        /// Método reponsável por retonar uma string com as expressões.
        /// </summary>
        /// <returns></returns>
        public static string StringPattern()
        {
            StringBuilder pattern = new StringBuilder();
            pattern.Append(Regexp.NUMBER);
            pattern.Append("|" + Regexp.VARIABLE);
            pattern.Append("|" + Regexp.COMMENT);
            pattern.Append("|" + Regexp.BINARYOP);
            pattern.Append("|" + Regexp.WRITESPACE);
            pattern.Append("|" + Regexp.STRING);
            pattern.Append("|" + Regexp.TYPE_STRING);
            pattern.Append("|" + Regexp.COMPARISION);
            pattern.Append("|" + Regexp.OPEN_BRACES);
            pattern.Append("|" + Regexp.CLOSE_BRACES);
            pattern.Append("|" + Regexp.OPEN_PARENTHESES);
            pattern.Append("|" + Regexp.CLOSE_PARENTHESES);
            pattern.Append("|" + Regexp.END_COMMAND);
            pattern.Append("|" + Regexp.INCREMENT);
            pattern.Append("|" + Regexp.DECREMENT);

            return pattern.ToString();
        }
    }
}
