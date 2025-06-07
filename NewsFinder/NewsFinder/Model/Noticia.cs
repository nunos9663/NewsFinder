using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFinder.Model
{
    public class Noticia
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public override string ToString()
        {
            return Titulo;
        }
    }
}

