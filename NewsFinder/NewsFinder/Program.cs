using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFinder.Controller;
using System.Windows.Forms;

namespace NewsFinder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppController controller = new AppController();
            controller.Iniciar();
        }
    }
}
