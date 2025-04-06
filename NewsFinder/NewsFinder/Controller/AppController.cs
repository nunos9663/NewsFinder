using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFinder.View;
using NewsFinder.Model;

namespace NewsFinder.Controller
{
    public class AppController
    {
        private LoginForm loginForm;
        private HomeForm homeForm;
        private NoticiaModel noticiaModel = new NoticiaModel();

        public AppController()
        {

            loginForm = new LoginForm();
            loginForm.PedidoLogin += ValidarLogin;


        }
        private async void ProcessarPesquisa(string texto)
        {
            var noticiasFormatadas = await noticiaModel.FormatarNoticiasAsync(texto);


            MessageBox.Show($"Foram recebidas {noticiasFormatadas.Count} notícias.");

            homeForm.MostrarNoticias(noticiasFormatadas);
        }



        public void Iniciar()
        {
            Application.Run(loginForm);
        }

        private void ValidarLogin(string username, string password)
        {
            bool sucesso = username == "admin" && password == "1234";

            if (sucesso)
            {
                loginForm.Hide();

                homeForm = new HomeForm();
                //homeForm.PedidoNoticias += FornecerNoticias;
                homeForm.PedidoPesquisa += ProcessarPesquisa;
                homeForm.Show();
            }

            loginForm.MostrarResultadoLogin(sucesso);
        }

        //private void FornecerNoticias()
        //{
        //    homeForm.MostrarNoticias(noticias);
        //}
    }
}
