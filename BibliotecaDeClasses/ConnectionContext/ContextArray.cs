using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.ConnectionContext
{
    public class ContextArray : IDisposable
    {
        private static Dictionary<string, dynamic> _sessoes = null;

        ~ContextArray()
        {
            Dispose();
        }

        public void Dispose()
        {
            if(_sessoes != null || _sessoes.Any())
            {
                _sessoes = null;
            }
        }

        ///<summary> 
        /// Resumo: Armazena os contextos passado via atribuiçao pela classe manupuladora
        ///</summary>
        public dynamic this[string key]
        {
            get
            {
                if (_sessoes == null)
                {
                    _sessoes = new Dictionary<string, dynamic>();
                }

                if(_sessoes.Any() && _sessoes.ContainsKey(key))
                {
                    return _sessoes[key];
                }

                return null;
            }

            set 
            { 
                _sessoes.Add(key, value); 
            }
        }

        /// <summary>
        /// Resumo: Retorna a quantidade de contextos guardados!
        /// </summary>
        public int Count => _sessoes.Any() ? _sessoes.Count() : 0;

        /// <summary>
        /// Resumo: Retorna o IEnumerable das sessões
        /// </summary>
        public IEnumerator GetEnumerator() => _sessoes.GetEnumerator();
        /// <summary>
        /// Resumo: Remove o contexto armazenado em memoria
        /// </summary>
        public void Remove(string key) => _sessoes.Remove(key);
        /// <summary>
        /// Resuma: Remove todos os contextos arazenados na memória!
        /// </summary>
        public void RemoveAll() => _sessoes = new Dictionary<string, object>();
    }
}
