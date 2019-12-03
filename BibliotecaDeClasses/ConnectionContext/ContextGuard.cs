using BibliotecaDeClasses.Utilidades.Attributs;
using System;

namespace BibliotecaDeClasses.ConnectionContext
{
    [Author("Gustavo de Oliveira Fernandes", Version = 1.1)]
    public class ContextGuard : IDisposable
    {
        private static ContextGuard _instancia = null;
        public ContextArray Sessoes { get; private set; }

        ~ContextGuard()
        {
            Dispose();
        }

        /// <summary>
        /// Resumo: Retorna uma instancia estatica do manupulador de contexto que contem um armazen de contexto
        /// </summary>
        public static ContextGuard Current
        {
            get
            {
                lock (new object())
                {
                    if (_instancia == null)
                    {
                        _instancia = new ContextGuard();
                    }
                }

                return _instancia;
            }
        }
        /// <summary>
        /// Resumo: Cria o armazem de contexto
        /// </summary>
        public void CrieArmazenDeContexto() => Sessoes = new ContextArray();

        public void Dispose()
        {
            if (_instancia != null)
            {
                Current.Sessoes.Dispose();
                _instancia = null;
            }
        }
    }
}
