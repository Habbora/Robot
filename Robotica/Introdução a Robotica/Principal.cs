using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introdução_a_Robotica
{
    public partial class Principal : Form
    {
        TransformadaView TView;

        Program.Converte c = new Program.Converte();
        

        public static String[,] Matriz_String = new String[6, 4];
        public static Double[,] Matriz_Double = new Double[6, 4];
        public static Boolean[,] Matriz_Var = new Boolean[6, 4];

        public static int EndLine;

        public Principal()
        {
            InitializeComponent();
        }

        public bool Armazenar()
        {
            EndLine = 0;

            // Verifica e valida a quantidade de entradas no programa.
            if      (M_1_1.Text == "" || M_1_2.Text == "" || M_1_3.Text == "" || M_1_4.Text == "")
            {
                MessageBox.Show("Valor não digitado na Linha 1.", "Erro de execução",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (M_2_1.Text == "" || M_2_2.Text == "" || M_2_3.Text == "" || M_2_4.Text == "")
            {
                EndLine = 1;
            }
            else if (M_3_1.Text == "" || M_3_2.Text == "" || M_3_3.Text == "" || M_3_4.Text == "")
            {
                EndLine = 2;
            }
            else if (M_4_1.Text == "" || M_4_2.Text == "" || M_4_3.Text == "" || M_4_4.Text == "")
            {
                EndLine = 3;
            }
            else if (M_5_1.Text == "" || M_5_2.Text == "" || M_5_3.Text == "" || M_5_4.Text == "")
            {
                EndLine = 4;
            }
            else if (M_6_1.Text == "" || M_6_2.Text == "" || M_6_3.Text == "" || M_6_4.Text == "")
            {
                EndLine = 5;
            }
            else EndLine = 6;
            
            // Salva os dados em uma Tabela de String.
            if (EndLine > 0)
            {
                Matriz_String[0, 0] = M_1_1.Text;
                Matriz_String[0, 1] = M_1_2.Text;
                Matriz_String[0, 2] = M_1_3.Text;
                Matriz_String[0, 3] = M_1_4.Text;
            }
            if (EndLine > 1)
            {
                Matriz_String[1, 0] = M_2_1.Text;
                Matriz_String[1, 1] = M_2_2.Text;
                Matriz_String[1, 2] = M_2_3.Text;
                Matriz_String[1, 3] = M_2_4.Text;
            }
            if (EndLine > 2)
            {
                Matriz_String[2, 0] = M_3_1.Text;
                Matriz_String[2, 1] = M_3_2.Text;
                Matriz_String[2, 2] = M_3_3.Text;
                Matriz_String[2, 3] = M_3_4.Text;
            }
            if (EndLine > 3)
            {
                Matriz_String[3, 0] = M_4_1.Text;
                Matriz_String[3, 1] = M_4_2.Text;
                Matriz_String[3, 2] = M_4_3.Text;
                Matriz_String[3, 3] = M_4_4.Text;
            }
            if (EndLine > 4)
            {
                Matriz_String[4, 0] = M_5_1.Text;
                Matriz_String[4, 1] = M_5_2.Text;
                Matriz_String[4, 2] = M_5_3.Text;
                Matriz_String[4, 3] = M_5_4.Text;
            }
            if (EndLine > 5)
            {
                Matriz_String[5, 0] = M_5_1.Text;
                Matriz_String[5, 1] = M_5_2.Text;
                Matriz_String[5, 2] = M_5_3.Text;
                Matriz_String[5, 3] = M_5_4.Text;
            }
            
            return true;
        }

        private void Tranformada_Click(object sender, EventArgs e)
        {
            if (Armazenar())
            {
                TView = new TransformadaView();
                this.TView.Show();
            }
        }

        private void Direta_Click(object sender, EventArgs e)
        {
            Armazenar();
        }
        
        // Função de controle dos TextBox para apenas numeros.
        public void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            // Pergunta se não é tecla de controle e nem uma tecla decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if(e.KeyChar != ',' && e.KeyChar != '-') // Pergunta se não é virgula ou sinal negativo.
                {
                    e.Handled = true; // Aborta se não for.
                }
                // Pergunta se é virgula.
                else if (e.KeyChar == ',') {
                    // Verifica se a vigula pode ser digitada na possição.
                    if ((sender as TextBox).Text.Length == 0 || (sender as TextBox).Text.IndexOf(',') > -1)
                    { // So digitado quando for o segundo caracter e não tiver outra virgula.
                        e.Handled = true; // Se não, Aborta.
                    }
                }
                // Pergunta se é um sinal de negativo
                else if (e.KeyChar == '-')
                {
                    // Verifica se o sinal pode ser digitado na possição.
                    if((sender as TextBox).Text.Length != 0)
                    {// So Digitado quando for o primeiro caracter.
                        e.Handled = true; // Se não, Aborta.
                    }
                }
            }
        }
        
        // Função de controle dos TextBox para apenas numeros.
        public void OnlyNumberAndX(object sender, KeyPressEventArgs e)
        {
            // Pergunta se não é tecla de controle e nem uma tecla decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == 'x')
                {
                    if ((sender as TextBox).Text.Length != 0)
                    {// So Digitado quando for o primeiro caracter.
                        e.Handled = true; // Se não, Aborta.
                    }
                }
                // Pergunta se é virgula.
                else if (e.KeyChar == ',')
                {
                    // Verifica se a vigula pode ser digitada na possição.
                    if ((sender as TextBox).Text.Length == 0 || (sender as TextBox).Text.IndexOf(',') > -1)
                    { // So digitado quando for o segundo caracter e não tiver outra virgula.
                        e.Handled = true; // Se não, Aborta.
                    }
                }
                // Pergunta se é um sinal de negativo
                else if (e.KeyChar == '-')
                {
                    // Verifica se o sinal pode ser digitado na possição.
                    if ((sender as TextBox).Text.Length != 0)
                    {// So Digitado quando for o primeiro caracter.
                        e.Handled = true; // Se não, Aborta.
                    }
                }
                else if (e.KeyChar != ',' && e.KeyChar != '-' && e.KeyChar != 'x')
                {
                    e.Handled = true;
                }
            }
            else if (char.IsDigit(e.KeyChar) && (sender as TextBox).Text.IndexOf('x') > -1)
                {
                    e.Handled = true;
                }
        }

        private void EsterEggs_Click(object sender, EventArgs e)
        {

        }

        private void Software_Click(object sender, EventArgs e)
        {

        }

        private void Desenvolvedor_Click(object sender, EventArgs e)
        {

        }
    }
}
