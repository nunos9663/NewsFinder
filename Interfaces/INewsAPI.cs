using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFinder.Model;

namespace NewsFinder.Interfaces
{
    public interface INewsAPI
    {
        Task<List<Noticia>> ObterNoticiasAsync(string termo);
    }
}
