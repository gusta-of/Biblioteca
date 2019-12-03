using System;

namespace BibliotecaDeClasses.Utilidades.Attributs
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public string Nome { get; }
        public double Version { get; set; }

        public AuthorAttribute(string nome)
        {
            Nome = nome;
            Version = 1.0;
        }
     }
}
