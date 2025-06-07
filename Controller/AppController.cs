using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFinder.View;
using NewsFinder.Model;
using NewsFinder.Interfaces;

namespace NewsFinder.Controller
{
    public class AppController
    {
        private LoginForm loginForm;
        private HomeForm homeForm;
        private readonly INewsAPI _newsService;

        public AppController(INewsAPI newsService)
        {
            _newsService = newsService;

            loginForm = new LoginForm();
            loginForm.PedidoLogin += ValidarLogin;
            loginForm.PedidoRegisto += MostrarMensagemRegisto;
        }

        private async void ProcessarPesquisa(string texto)
        {
            var noticiasFormatadas = await _newsService.ObterNoticiasAsync(texto);

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

        private void MostrarMensagemRegisto()
        {
            RegistoForm registo = new RegistoForm();
            registo.ShowDialog();
        }


    }
}
