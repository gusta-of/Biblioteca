using BibliotecaDeClasses.Utilidades.Attributs;
using System;

namespace BibliotecaDeClasses.ConnectionContext
{
    [Author("Gustavo de Oliveira Fernandes", Version = 1.1)]
    public class ContextGuard : IDisposable
    {
        private static ContextGuard _instance = null;
        public ContextArray Sessions { get; private set; }

        ~ContextGuard()
        {
            Dispose();
        }

        /// <summary>
        /// Resumo: Retorna uma instancia estática que contém a coleção de sessões criadas
        /// </summary>
        public static ContextGuard Current
        {
            get
            {
                lock (new object())
                {
                    if (_instance == null)
                    {
                        _instance = new ContextGuard();
                    }
                }

                return _instance;
            }
        }
        /// <summary>
        /// Resumo: Cria a instancia única para a coleção que conterá todas as sessões
        /// </summary>
        public void Create() => Sessions = new ContextArray();

        public void Dispose()
        {
            if (_instance != null)
            {
                Current.Sessions.Dispose();
                _instance = null;
            }
        }
    }
}
