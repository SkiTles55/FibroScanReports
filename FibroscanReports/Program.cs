using System;
using System.Windows.Forms;

namespace FibroscanReports
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Form1 f = null;
            if (args != null && args.Length > 0)
            {
                string fileName = args[0];
                //Существует ли файл?
                if (System.IO.File.Exists(fileName))
                {
                    f = new Form1(fileName);
                }
                //Файл не существует :(
                else
                {
                    MessageBox.Show("File does not exist!", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    f = new Form1();
                }
            }
            //без аргументов
            else
            {
                f = new Form1();
            }
            Application.Run(f);
        }
    }
}
