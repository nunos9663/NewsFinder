
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFinder.Model;

namespace NewsFinder.Model
{
    public class NoticiaModel
    {
        private NewsAPI api = new NewsAPI();

        public async Task<List<Noticia>> FormatarNoticiasAsync(string texto)
        {
            return await api.ObterNoticiasAsync(texto);
        }
    }
}

