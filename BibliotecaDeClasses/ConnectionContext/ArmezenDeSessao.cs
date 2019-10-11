using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.ConnectionContext
{
    public class ArmezenDeSessao
    {
        private static Dictionary<string, object> _sessoes = null;

        //Resumo:
        // Armazena os contextos passado via atribuiçao pela classe manupuladora
        public object this[string key]
        {
            get
            {
                if (_sessoes == null)
                {
                    _sessoes = new Dictionary<string, object>();
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

        //Resumo:
        // Retorna a quantidade de contextos guardados!
        public int Count => _sessoes.Any() ? _sessoes.Count() : 0;
        //Resumo:
        // Retorna o IEnumerable das sessões
        public IEnumerator GetEnumerator() => _sessoes.GetEnumerator();
        //Resumo:
        //  Remove o contexto armazenado em memoria
        public void Remove(string key) => _sessoes.Remove(key);
        //Resuma:
        //  Remove todos os contextos arazenados na memória!
        public void RemoveAll(string key) => _sessoes = new Dictionary<string, object>();
    }
}
