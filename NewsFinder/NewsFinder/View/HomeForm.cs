using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NewsFinder.Model;

namespace NewsFinder.View
{
    public partial class HomeForm : Form
    {
        private Button btnPesquisar;
        private TextBox txtPesquisa;
        private Label label1;
        private ListBox listBoxNoticias;

        public delegate void PedidoPesquisaHandler(string texto);
        public event PedidoPesquisaHandler PedidoPesquisa;

        //public delegate void PedidoNoticiasHandler();
        //public event PedidoNoticiasHandler PedidoNoticias;

        public HomeForm()
        {
            InitializeComponent();
        }

        //private void HomeForm_Load(object sender, EventArgs e)
        //{
        //    PedidoNoticias?.Invoke(); // <- Dispara o evento
        //}

        public void MostrarNoticias(List<Noticia> noticias)
        {
            listBoxNoticias.Items.Clear();
            foreach (var noticia in noticias)
            {
                listBoxNoticias.Items.Add(noticia);
            }
        }

        private void listBoxNoticias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNoticias.SelectedItem is Noticia noticia)
            {
                MessageBox.Show(noticia.Conteudo, noticia.Titulo);
            }
        }

        public async void FazerPesquisaDireta(string termo)
        {
            try
            {
                var api = new NewsAPI();
                var noticias = await api.ObterNoticiasAsync(termo);
                MostrarNoticias(noticias);
                MessageBox.Show($"Foram encontradas {noticias.Count} notícias.");

            }
            catch (ErroDeLigacaoAPIException ex)
            {
                MessageBox.Show("Erro de ligação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoticiaNaoEncontradaException ex)
            {
                MessageBox.Show("Aviso: " + ex.Message, "Nenhuma notícia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeComponent()
        {
            this.listBoxNoticias = new System.Windows.Forms.ListBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxNoticias
            // 
            this.listBoxNoticias.FormattingEnabled = true;
            this.listBoxNoticias.ItemHeight = 16;
            this.listBoxNoticias.Location = new System.Drawing.Point(192, 198);
            this.listBoxNoticias.Name = "listBoxNoticias";
            this.listBoxNoticias.Size = new System.Drawing.Size(184, 148);
            this.listBoxNoticias.TabIndex = 0;
            this.listBoxNoticias.SelectedIndexChanged += new System.EventHandler(this.listBoxNoticias_SelectedIndexChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(344, 154);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(91, 23);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(149, 155);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(153, 22);
            this.txtPesquisa.TabIndex = 2;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escreve o tópico a pesquisar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // HomeForm
            // 
            this.ClientSize = new System.Drawing.Size(620, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.listBoxNoticias);
            this.Name = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string texto = txtPesquisa.Text;
            //PedidoPesquisa?.Invoke(texto);
            FazerPesquisaDireta(texto);
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }
    }

}
