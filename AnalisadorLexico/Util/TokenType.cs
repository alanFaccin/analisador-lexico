using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe responsável pelo ENUM que armazena os tipos de tokens.
    /// </summary>
    class TokenType
    {

        /// <summary>
        /// ENUM responsável por armazenar os tipos de tokens. 
        /// </summary>
        public enum Type
        {
            PARENTESEA,
            PARENTESEF,
            COLCHETEA,
            COLCHETEF,
            CHAVESA,
            CHAVESF,
            ATRIBUICAO,
            OPERACAO,
            LOGICO,
            COMPARACAO,
            TIPO,
            NUMERO,
            STRING,
            INICIO,
            FIM,
            ENTRADA,
            SAIDA,
            CONSTANTE,
            VARIAVEL,
            REPETICAO,
            CONDICAO,
            FIM_INSTRUCAO,
            COMENTARIO,
            ERROR,
            ESTRUTURA1,
            ESTRUTURA2,
            EXPRESSAO
        }
    }
}