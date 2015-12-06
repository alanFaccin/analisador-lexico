using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico.Util
{
    /// <summary>
    /// Classe responsável por armazenar os simbolos.
    /// </summary>
    class Symbol
    {
        public Dictionary<string, TokenType.Type> listSymbols { get; set; }

        /// <summary>
        /// Método construtor da classe.
        /// </summary>
        public Symbol()
        {
            this.listSymbols = new Dictionary<string, TokenType.Type>();
            this.listSymbols.Add("INTEIRO", TokenType.Type.TIPO);
            this.listSymbols.Add("REAL", TokenType.Type.TIPO);
            this.listSymbols.Add("LOGICO", TokenType.Type.TIPO);
            this.listSymbols.Add("LITERAL", TokenType.Type.TIPO);

            this.listSymbols.Add("(", TokenType.Type.PARENTESEA);
            this.listSymbols.Add(")", TokenType.Type.PARENTESEF);            
            this.listSymbols.Add("{", TokenType.Type.CHAVESA);
            this.listSymbols.Add("}", TokenType.Type.CHAVESF);
            this.listSymbols.Add("[", TokenType.Type.COLCHETEA);
            this.listSymbols.Add("]", TokenType.Type.COLCHETEF);

            this.listSymbols.Add(">", TokenType.Type.COMPARACAO);
            this.listSymbols.Add("<", TokenType.Type.COMPARACAO);
            this.listSymbols.Add(">=", TokenType.Type.COMPARACAO);
            this.listSymbols.Add("<=", TokenType.Type.COMPARACAO);
            this.listSymbols.Add("==", TokenType.Type.COMPARACAO);
            this.listSymbols.Add("<>", TokenType.Type.COMPARACAO);

            this.listSymbols.Add("=", TokenType.Type.ATRIBUICAO);

            this.listSymbols.Add("+", TokenType.Type.OPERACAO);
            this.listSymbols.Add("-", TokenType.Type.OPERACAO);
            this.listSymbols.Add("*", TokenType.Type.OPERACAO);
            this.listSymbols.Add("/", TokenType.Type.OPERACAO);

            this.listSymbols.Add(";", TokenType.Type.FIM_INSTRUCAO);

            this.listSymbols.Add("INICIO", TokenType.Type.INICIO);
            this.listSymbols.Add("FIM", TokenType.Type.FIM);

            this.listSymbols.Add("E", TokenType.Type.LOGICO);
            this.listSymbols.Add("OU", TokenType.Type.LOGICO);
            this.listSymbols.Add("NAO", TokenType.Type.LOGICO);

            this.listSymbols.Add("SE", TokenType.Type.CONDICAO);
            this.listSymbols.Add("ENTAO", TokenType.Type.CONDICAO);
            this.listSymbols.Add("SENAO", TokenType.Type.CONDICAO);
            this.listSymbols.Add("FIM_SE", TokenType.Type.CONDICAO);

            this.listSymbols.Add("PARA", TokenType.Type.REPETICAO);
            this.listSymbols.Add("DE", TokenType.Type.REPETICAO);
            this.listSymbols.Add("ATE", TokenType.Type.REPETICAO);
            this.listSymbols.Add("PASSO", TokenType.Type.REPETICAO);
            this.listSymbols.Add("FACA", TokenType.Type.REPETICAO);
            this.listSymbols.Add("FIM_PARA", TokenType.Type.REPETICAO);
            this.listSymbols.Add("ENQUANTO", TokenType.Type.REPETICAO);
            this.listSymbols.Add("FIM_ENQUANTO", TokenType.Type.REPETICAO);
            this.listSymbols.Add("REPITA", TokenType.Type.REPETICAO);
            this.listSymbols.Add("PARE", TokenType.Type.REPETICAO);
        }
    }
}
