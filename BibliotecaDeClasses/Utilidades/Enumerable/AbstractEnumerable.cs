using BibliotecaDeClasses.Utilidades.Attributs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.Utilidades.Enumerable
{
    [Author("Gustavo de Oliveira Fernandes", Version = 1.0)]
    public abstract class AbstractEnumerable<T, K> : IEnumerable<K>, IComparable where T : IEnumerable<K>
    {
        private Func<string> _descricaoDelegate;
        protected AbstractEnumerable(K key, Func<string> descricao)
        {
            Codigo = key;
            _descricaoDelegate = descricao;
        }

        public K Codigo { get; protected set; }

        public string Descricao
        {
            get
            {
                return _descricaoDelegate();
            }
            protected set
            {
                _descricaoDelegate = () => value;
            }
        }

        public T Get(T key)
        {
            return GetAll().Find(i => i.Codigo.Equals(key));
        }

        public List<T> GetAll()
        {
            return GetAll<T>();
        }

        protected static List<TEnumerador> GetAll<TEnumerador>() where TEnumerador : IEnumerable<K>
        {
            var tipo = typeof(TEnumerador);
            return tipo.GetFields(BindingFlags.Static | BindingFlags.Public).Select(campo => (TEnumerador)campo.GetValue(null)).ToList();
        }

        public bool Equals(AbstractEnumerable<T, K> obj)
        {
            return (obj != null) && obj.Codigo.Equals(Codigo);
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

           if(!(obj is AbstractEnumerable<T, K>))
            {
                throw new ArgumentException("Objeto não é do tipo do Enumerador");
            }

            return ((IComparable)Codigo).CompareTo(((AbstractEnumerable<T, K>)obj).Codigo);
        }
    }
}
