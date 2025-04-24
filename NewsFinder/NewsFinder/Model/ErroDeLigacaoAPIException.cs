using System;
using NewsFinder.Model;

namespace NewsFinder.Model
{
	public class ErroDeLigacaoAPIException : Exception
	{
		public ErroDeLigacaoAPIException() : base("N�o foi poss�vel ligar � API de not�cias.") { }

		public ErroDeLigacaoAPIException(string mensagem) : base(mensagem) { }

		public ErroDeLigacaoAPIException(string mensagem, Exception inner) : base(mensagem, inner) { }
	}
}
