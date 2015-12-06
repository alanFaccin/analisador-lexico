using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AnalisadorLexico
{
    /// <summary>
    /// Classe responsável pelo FormDefault,
    /// </summary>
    public partial class FormDefault : Form
    {
        private IList<Util.Token> listTokens;

        /// <summary>
        /// Método construtor da classe.
        /// </summary>
        public FormDefault()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método responsável pelo evento: abrirToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.AutoUpgradeEnabled = false;
            this.openFileDialog.DereferenceLinks = false;

            DialogResult DialogResult = this.openFileDialog.ShowDialog();

            if (DialogResult == DialogResult.OK)
            {
                IList<string> valueRead = this.openAndReadFile();
                richTextBoxEditor.Text = "";
                populateRichText(valueRead);
            }
        }

        /// <summary>
        /// Método responsável pelo evento: salvarToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult DialogResult = this.saveFileDialog.ShowDialog();

            if (DialogResult == DialogResult.OK)
            {
                saveFile();
            }
        }

        /// <summary>
        /// Método responsável pelo evento: sairToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair do editor", "Sair", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Método responsável pelo evento: richTextBox1_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox_Click(object sender, EventArgs e)
        {
            updatePositionCursor();
        }

        /// <summary>
        /// Método responsável pelo evento: richTextBox_KeyDown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                updatePositionCursor();
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                processLexer();
            }
        }

        /// <summary>
        /// Método responsável pelo evento: analiseLexicaToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void analiseLexicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processLexer();
        }

        /// <summary>
        /// Método responsável por ler o conteúdo de um arquivo.
        /// </summary>
        /// <returns></returns>
        private IList<string> openAndReadFile()
        {
            using (Stream Stream = File.Open(openFileDialog.FileName, FileMode.Open))
            using (StreamReader streamReadFile = new StreamReader(Stream))
            {
                IList<string> listLinesRead = new List<string>();

                string mensagem;

                while ((mensagem = streamReadFile.ReadLine()) != null)
                {
                    listLinesRead.Add(mensagem);
                }

                return listLinesRead;
            }
        }

        /// <summary>
        /// Método responsável por salvar o conteúdo do richText em um arquivo.
        /// </summary>
        /// <returns></returns>
        private void saveFile()
        {
            using (Stream Stream = File.Open(saveFileDialog.FileName, FileMode.Create))
            using (StreamWriter writter = new StreamWriter(Stream))
            {
                foreach (string item in richTextBoxEditor.Lines)
                {
                    writter.WriteLine(item);
                }

                writter.Close();
            }
        }

        /// <summary>
        /// Método responsável por popular o componente richText.
        /// </summary>
        /// <param name="valueRead"></param>
        private void populateRichText(IList<string> valueRead)
        {
            foreach (string item in valueRead)
            {
                richTextBoxEditor.Text += item + Environment.NewLine;
            }
        }

        /// <summary>
        /// Método responsável pelo evento: sairToolStripMenuItem_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if ("".Equals(this.richTextBoxEditor.Text))
            {
                this.listView.Items.Clear();
            }
        }

        /// <summary>
        /// Método responsável por chamar o analisador léxico e popular a listView.
        /// </summary>
        private void processLexer()
        {
            listTokens = Lexico.Analyzer.Analyze(this.richTextBoxEditor.Text);

            this.listView.Items.Clear();

            string[] arr = new string[5];
            int i = 1;

            foreach (Util.Token token in listTokens)
            {
                arr[0] = i.ToString();
                arr[1] = token.Type.ToString();
                arr[2] = token.Lexema;
                arr[3] = token.Position.Line.ToString();
                arr[4] = token.Position.Column.ToString();

                listView.Items.Add(new ListViewItem(arr));
                i++;
            }
        }

        /// <summary>
        ///Método responsável por atualizar na barra de status a posição do cursor no texto.
        /// </summary>
        private void updatePositionCursor()
        {
            int line = richTextBoxEditor.GetLineFromCharIndex(richTextBoxEditor.SelectionStart);
            int column = richTextBoxEditor.SelectionStart - richTextBoxEditor.GetFirstCharIndexFromLine(line);

            this.toolStripStatusLinha.Text = "Linha: " + line;
            this.toolStripStatusColuna.Text = "Coluna: " + column;
        }

        /// <summary>
        /// Método responsável pelo syntax highlighter do richTextBox.
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="color"></param>
        private void changeColor(string tokens, Color color)
        {
            Regex rex = new Regex(@tokens);
            MatchCollection mc = rex.Matches(richTextBoxEditor.Text);

            int StartCursorPosition = richTextBoxEditor.SelectionStart;

            foreach (Match m in mc)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;
                richTextBoxEditor.Select(startIndex, StopIndex);
                richTextBoxEditor.SelectionColor = color;
            }

            richTextBoxEditor.SelectionColor = Color.Black;
            richTextBoxEditor.SelectionStart = StartCursorPosition;
        }
    }
}
