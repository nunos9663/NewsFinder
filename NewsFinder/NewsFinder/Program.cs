using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFinder.Controller;
using System.Windows.Forms;
using NewsFinder.Interfaces;
using NewsFinder.Model;

namespace NewsFinder
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            INewsAPI newsService = new NewsAPI(); // cria a instância da classe que implementa a interface
            AppController controller = new AppController(newsService);
            controller.Iniciar();
        }
    }
}



