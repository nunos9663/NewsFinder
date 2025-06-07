using System;
using NewsFinder.Model;

namespace NewsFinder.Model
{
	public class ErroDeLigacaoAPIException : Exception
	{
		public ErroDeLigacaoAPIException() : base("Não foi possível ligar à API de notícias.") { }

		public ErroDeLigacaoAPIException(string mensagem) : base(mensagem) { }

		public ErroDeLigacaoAPIException(string mensagem, Exception inner) : base(mensagem, inner) { }
	}
}
