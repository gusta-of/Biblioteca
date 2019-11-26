using System;

namespace BibliotecaDeClasses.ConnectionContext
{
    public class Context : IDisposable
    {
        private static Context _instancia = null;
        public ArrayConnection Sessoes { get; private set; }

        ~Context()
        {
            Dispose();
        }

        /// <summary>
        /// Resumo: Retorna uma instancia estatica do manupulador de contexto que contem um armazen de contexto
        /// </summary>
        public static Context Current
        {
            get
            {
                lock (new object())
                {
                    if (_instancia == null)
                    {
                        _instancia = new Context();
                    }
                }

                return _instancia;
            }
        }
        /// <summary>
        /// Resumo: Cria o armazem de contexto
        /// </summary>
        public void CrieArmazenDeContexto() => Sessoes = new ArrayConnection();

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
