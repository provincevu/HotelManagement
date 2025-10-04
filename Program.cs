using System;
using System.Windows.Forms;

namespace HotelManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DataBase.InitializeDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}