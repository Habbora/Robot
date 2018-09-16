using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introdução_a_Robotica
{
    public partial class TransformadaView : Form
    {
        private static String[,]  Matriz_String = Principal.Matriz_String;

        private static Double[,]  Matriz_Double = new Double[6, 4];
        private static Double[,,] Matriz        = new Double[6, 4, 4];
        private static Double[,]  MatrizTemp    = new Double[4, 4];
        private static Double[,]  MatrizAns     = new Double[4, 4];

        private static int EndLine = Principal.EndLine;

        private Program.Converte c = new Program.Converte();

        public TransformadaView()
        {
            InitializeComponent();
            IncluiItems(Principal.EndLine);
            Bloco.SelectedIndex = Principal.EndLine;
            Atualizar();
            
        }

        private void IncluiItems(int x)
        {
            System.Object[] ItemRange = new System.Object[x + 1];

            for (int i = 0; i < x; i++)
            {
                ItemRange[i] = "T " + i + "_" + (i + 1);
            }

            ItemRange[x] = "T 0_" + x;

            Bloco.Items.Clear();

            Bloco.Items.AddRange(ItemRange);
        }
        
        private void Atualizar()
        {
            int select = Bloco.SelectedIndex;

            // Salva os dados na matriz_double
            for (int x = 0; x < EndLine; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (Matriz_String[x,y] != "x")
                    {
                        Matriz_Double[x, y] = c.StringToDouble_PTBR(Matriz_String[x,y]);
                    }
                }
            }
            
            
            if (Matriz_String[0, 2] == "x")
            {
                Txt_1.Text = "d_1";
                Matriz_Double[0, 2] = c.StringToDouble_PTBR(TxtBox_1.Text);
                TxtBox_1.Enabled = true;
            }
            else if (Matriz_String[0, 3] == "x")
            {
                Txt_1.Text = "t_1";
                Matriz_Double[0, 3] = c.StringToDouble_PTBR(TxtBox_1.Text);
                TxtBox_1.Enabled = true;

            }
            if (Matriz_String[1, 2] == "x")
            {
                Txt_2.Text = "d_2";
                Matriz_Double[1, 2] = c.StringToDouble_PTBR(TxtBox_2.Text);
                TxtBox_2.Enabled = true;
            }
            else if (Matriz_String[1, 3] == "x")
            {
                Txt_2.Text = "t_2";
                Matriz_Double[1, 3] = c.StringToDouble_PTBR(TxtBox_2.Text);
                TxtBox_2.Enabled = true;
            }
            if (Matriz_String[2, 2] == "x")
            {
                Txt_3.Text = "d_3";
                Matriz_Double[2, 2] = c.StringToDouble_PTBR(TxtBox_3.Text);
                TxtBox_3.Enabled = true;
            }
            else if (Matriz_String[2, 3] == "x")
            {
                Txt_3.Text = "t_3";
                Matriz_Double[2, 3] = c.StringToDouble_PTBR(TxtBox_3.Text);
                TxtBox_3.Enabled = true;
            }
            if (Matriz_String[3, 2] == "x")
            {
                Txt_4.Text = "d_4";
                Matriz_Double[3, 2] = c.StringToDouble_PTBR(TxtBox_4.Text);
                TxtBox_4.Enabled = true;
            }
            else if (Matriz_String[3, 3] == "x")
            {
                Txt_4.Text = "t_4";
                Matriz_Double[3, 3] = c.StringToDouble_PTBR(TxtBox_4.Text);
                TxtBox_4.Enabled = true;
            }
            if (Matriz_String[4, 2] == "x")
            {
                Txt_5.Text = "d_5";
                Matriz_Double[4, 2] = c.StringToDouble_PTBR(TxtBox_5.Text);
                TxtBox_5.Enabled = true;
            }
            else if (Matriz_String[4, 3] == "x")
            {
                Txt_5.Text = "t_5";
                Matriz_Double[4, 3] = c.StringToDouble_PTBR(TxtBox_5.Text);
                TxtBox_5.Enabled = true;
            }
            if (Matriz_String[5, 2] == "x")
            {
                Txt_6.Text = "d_6";
                Matriz_Double[5, 2] = c.StringToDouble_PTBR(TxtBox_6.Text);
                TxtBox_6.Enabled = true;
            }
            else if (Matriz_String[5, 3] == "x")
            {
                Txt_6.Text = "t_6";
                Matriz_Double[5, 3] = c.StringToDouble_PTBR(TxtBox_6.Text);
                TxtBox_6.Enabled = true;
            }
            
            // Converte os angulos de graus para Rad
            for (int l = 0; l < EndLine; l++)
            {
                Matriz_Double[l, 1] = Matriz_Double[l, 1] * Math.PI / 180;
                Matriz_Double[l, 3] = Matriz_Double[l, 3] * Math.PI / 180;
            }

            // Gera as matrizes de transformação
            for (int m = 0; m < EndLine; m++)
            {
                Matriz[m, 0, 0] = Math.Cos(Matriz_Double[m, 3]);
                Matriz[m, 0, 1] = -Math.Sin(Matriz_Double[m, 3]);
                Matriz[m, 0, 2] = 0;
                Matriz[m, 0, 3] = Matriz_Double[m, 0];
                Matriz[m, 1, 0] = Math.Sin(Matriz_Double[m, 3]) * Math.Cos(Matriz_Double[m, 1]);
                Matriz[m, 1, 1] = Math.Cos(Matriz_Double[m, 3]) * Math.Cos(Matriz_Double[m, 1]);
                Matriz[m, 1, 2] = -Math.Sin(Matriz_Double[m, 1]);
                Matriz[m, 1, 3] = -Math.Sin(Matriz_Double[m, 1]) * Matriz_Double[m, 2];
                Matriz[m, 2, 0] = Math.Sin(Matriz_Double[m, 3]) * Math.Sin(Matriz_Double[m, 1]);
                Matriz[m, 2, 1] = Math.Cos(Matriz_Double[m, 3]) * Math.Sin(Matriz_Double[m, 1]);
                Matriz[m, 2, 2] = Math.Cos(Matriz_Double[m, 1]);
                Matriz[m, 2, 3] = Math.Cos(Matriz_Double[m, 1]) * Matriz_Double[m, 2];
                Matriz[m, 3, 0] = 0;
                Matriz[m, 3, 1] = 0;
                Matriz[m, 3, 2] = 0;
                Matriz[m, 3, 3] = 1;
            }
            
            // Define MatrizTemp em Matriz[0].
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    MatrizTemp[x, y] = Matriz[0, x, y];
                }
            }

            // Multiplicar as matrizes de tranformação.
            for (int i = 1; i < EndLine; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        for (int z = 0; z < 4; z++)
                        {
                            MatrizAns[x, y] += MatrizTemp[x, z] * Matriz[i, z, y];
                        }
                    }
                }

                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        MatrizTemp[x, y] = MatrizAns[x, y];
                        MatrizAns[x, y] = 0;
                    }
                }
            }

            // Remove valores muito pequenos
            for (int i = 0; i < 6; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if(Matriz[i, x, y] < 0.0001 && Matriz[i, x, y] > -0.0001)
                        {
                            Matriz[i, x, y] = 0;
                        }
                    }
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (MatrizTemp[x, y] < 0.0001 && MatrizTemp[x, y] > -0.0001)
                    {
                        MatrizTemp[x, y] = 0;
                    }
                }
            }


            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (MatrizTemp[x, y] < -0.0001 && MatrizTemp[x, y] > 0.0001)
                    {
                        MatrizTemp[x, y] = 0;
                    }
                }
            }

            // Exibe a matriz de saida do programa
            if (select < Principal.EndLine)
            {
                M_1_1.Text = Convert.ToString(Matriz[select, 0, 0]);
                M_1_2.Text = Convert.ToString(Matriz[select, 0, 1]);
                M_1_3.Text = Convert.ToString(Matriz[select, 0, 2]);
                M_1_4.Text = Convert.ToString(Matriz[select, 0, 3]);

                M_2_1.Text = Convert.ToString(Matriz[select, 1, 0]);
                M_2_2.Text = Convert.ToString(Matriz[select, 1, 1]);
                M_2_3.Text = Convert.ToString(Matriz[select, 1, 2]);
                M_2_4.Text = Convert.ToString(Matriz[select, 1, 3]);

                M_3_1.Text = Convert.ToString(Matriz[select, 2, 0]);
                M_3_2.Text = Convert.ToString(Matriz[select, 2, 1]);
                M_3_3.Text = Convert.ToString(Matriz[select, 2, 2]);
                M_3_4.Text = Convert.ToString(Matriz[select, 2, 3]);

                M_4_1.Text = Convert.ToString(Matriz[select, 3, 0]);
                M_4_2.Text = Convert.ToString(Matriz[select, 3, 1]);
                M_4_3.Text = Convert.ToString(Matriz[select, 3, 2]);
                M_4_4.Text = Convert.ToString(Matriz[select, 3, 3]);
            }
            else
            {
                M_1_1.Text = Convert.ToString(MatrizTemp[0, 0]);
                M_1_2.Text = Convert.ToString(MatrizTemp[0, 1]);
                M_1_3.Text = Convert.ToString(MatrizTemp[0, 2]);
                M_1_4.Text = Convert.ToString(MatrizTemp[0, 3]);

                M_2_1.Text = Convert.ToString(MatrizTemp[1, 0]);
                M_2_2.Text = Convert.ToString(MatrizTemp[1, 1]);
                M_2_3.Text = Convert.ToString(MatrizTemp[1, 2]);
                M_2_4.Text = Convert.ToString(MatrizTemp[1, 3]);

                M_3_1.Text = Convert.ToString(MatrizTemp[2, 0]);
                M_3_2.Text = Convert.ToString(MatrizTemp[2, 1]);
                M_3_3.Text = Convert.ToString(MatrizTemp[2, 2]);
                M_3_4.Text = Convert.ToString(MatrizTemp[2, 3]);

                M_4_1.Text = Convert.ToString(MatrizTemp[3, 0]);
                M_4_2.Text = Convert.ToString(MatrizTemp[3, 1]);
                M_4_3.Text = Convert.ToString(MatrizTemp[3, 2]);
                M_4_4.Text = Convert.ToString(MatrizTemp[3, 3]);
            }
        }

        private void Exibir_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }
    }
}
