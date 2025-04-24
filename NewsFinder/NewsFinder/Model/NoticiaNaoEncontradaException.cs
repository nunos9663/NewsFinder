using System;
using NewsFinder.Model;


namespace NewsFinder.Model
{
    public class NoticiaNaoEncontradaException : Exception
    {
        public NoticiaNaoEncontradaException() : base("Não foram encontradas notícias para o termo pesquisado.") { }

        public NoticiaNaoEncontradaException(string mensagem) : base(mensagem) { }

        public NoticiaNaoEncontradaException(string mensagem, Exception inner) : base(mensagem, inner) { }
    }
}
