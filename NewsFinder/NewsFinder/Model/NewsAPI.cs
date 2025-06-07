using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Dynamic;
using NewsFinder.Model;
using NewsFinder.Interfaces;

namespace NewsFinder.Model
{
    public class NewsAPI : INewsAPI
    {
        private const string apiKey = "496c658a29294fd2be403ce5515b045a";
        private const string endpoint = "https://newsapi.org/v2/everything?q={0}&language=pt&apiKey={1}";


        public async Task<List<Noticia>> ObterNoticiasAsync(string texto)
        {
            using (var client = new HttpClient())
            {
                // Define headers que evitam rejeição
                client.DefaultRequestHeaders.Add("User-Agent", "NewsFinderApp");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                string termoCodificado = Uri.EscapeDataString(texto);
                string url = string.Format(endpoint, termoCodificado, apiKey);

                //string resposta = await client.GetStringAsync(url);
                string resposta;
                try
                {
                    resposta = await client.GetStringAsync(url);
                }
                catch (HttpRequestException ex)
                {
                    throw new ErroDeLigacaoAPIException("Erro ao conectar à API de notícias.", ex);
                }


                dynamic json = JsonConvert.DeserializeObject(resposta);
                var lista = new List<Noticia>();

                foreach (var artigo in json.articles)
                {
                    lista.Add(new Noticia
                    {
                        Titulo = artigo.title,
                        Conteudo = artigo.description
                    });
                }

                if (lista.Count == 0)
                {
                    throw new NoticiaNaoEncontradaException($"Nenhuma notícia encontrada para o termo: {texto}");
                }


                return lista;
            }
        }

    }


}
