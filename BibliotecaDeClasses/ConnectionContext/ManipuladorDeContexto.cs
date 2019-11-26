﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.ConnectionContext
{
    public class ManipuladorDeContexto : IDisposable
    {
        private static ManipuladorDeContexto _instancia = null;
        public ArrayConnection Sessoes { get; private set; }

        ~ManipuladorDeContexto()
        {
            Dispose();
        }

        /// <summary>
        /// Resumo: Retorna uma instancia estatica do manupulador de contexto que contem um armazen de contexto
        /// </summary>
        public static ManipuladorDeContexto Current
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
