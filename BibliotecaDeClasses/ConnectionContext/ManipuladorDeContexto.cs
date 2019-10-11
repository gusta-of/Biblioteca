using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.ConnectionContext
{
    public class ManipuladorDeContexto
    {
        private static ManipuladorDeContexto _instancia = null;

        public ArmezenDeSessao Sessoes { get; private set; }
        //Resumo:
        //  Retorna uma instancia estatica do manupulador de contexto que contem um armazen de contexto
        public static ManipuladorDeContexto Instancia
        {
            get
            {
                lock (new object())
                {
                    if (_instancia == null)
                    {
                        _instancia = new ManipuladorDeContexto();
                    }
                }

                return _instancia;
            }
        }
        //Resumo:
        //  Cria o armazem de contexto
        public void CrieArmazenDeContexto() => Sessoes = new ArmezenDeSessao();

    }
}
