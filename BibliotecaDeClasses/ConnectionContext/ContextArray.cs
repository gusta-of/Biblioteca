using BibliotecaDeClasses.Utilidades.Attributs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaDeClasses.ConnectionContext
{
    [Author("Gustavo de Oliveira Fernandes", Version = 1.1)]
    public class ContextArray : IDisposable
    {
        private static Dictionary<string, dynamic> _sessions = null;

        ~ContextArray()
        {
            Dispose();
        }

        public void Dispose()
        {
            if(_sessions != null || _sessions.Any())
            {
                _sessions = null;
            }
        }

        ///<summary> 
        /// Resumo: Armazena todo e qualquer contexto passado, por ser uma referencia dinâmica será ignorado o tipo
        ///</summary>
        public dynamic this[string key]
        {
            get
            {
                if (_sessions == null)
                {
                    _sessions = new Dictionary<string, dynamic>();
                }

                if(_sessions.Any() && _sessions.ContainsKey(key))
                {
                    return _sessions[key];
                }

                return null;
            }

            set 
            { 
                _sessions.Add(key, value); 
            }
        }

        /// <summary>
        /// Resumo: Retorna a quantidade de sessões guardadas!
        /// </summary>
        public int Count => _sessions.Any() ? _sessions.Count() : 0;

        /// <summary>
        /// Resumo: Retorna o IEnumerator da coleção de sessões
        /// </summary>
        public IEnumerator GetEnumerator() => _sessions.GetEnumerator();
        /// <summary>
        /// Resumo: Remove o contexto armazenado em memoria
        /// </summary>
        public void Remove(string key) => _sessions.Remove(key);
        /// <summary>
        /// Resuma: Remove todos os contextos arazenados na memória!
        /// </summary>
        public void RemoveAll() => _sessions = new Dictionary<string, object>();
    }
}
