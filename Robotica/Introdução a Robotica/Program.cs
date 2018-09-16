using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introdução_a_Robotica
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }

        public class Converte
        {
            public double StringToDouble_PTBR(String txt)
            {
                bool x = false, n = false;
                int dec = 0, length = txt.Length;
                double memoria = 0;

                for (int cont = 0; cont < length; cont++)
                {
                    if (txt[cont] == ',' || txt[cont] == '.')
                    {
                        x = true;
                        dec = 1;
                    }
                    else if (txt[cont] >= 48 && txt[cont] <= 57)
                    {
                        if (x) dec *= 10;
                        memoria *= 10;
                        memoria += txt[cont] - 48;
                    }
                    else if (txt[cont] == '-') n = true;
                }

                if (dec > 0) memoria /= dec;
                if (n) memoria *= -1;

                return memoria;
            }
        }


    }
}
