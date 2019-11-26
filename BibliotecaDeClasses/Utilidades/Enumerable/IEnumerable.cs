using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.Utilidades.Enumerable
{
    public interface IEnumerable<T>
    {
        T Codigo { get; }
        string Descricao { get; }
    }
}
