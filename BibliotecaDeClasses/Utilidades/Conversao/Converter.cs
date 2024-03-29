﻿using BibliotecaDeClasses.Utilidades.Attributs;
using System;
using System.Globalization;

namespace BibliotecaDeClasses.Utilidades.Conversao
{
    [Author("Gustavo de Oliveira Fernandes", Version = 1.0)]
    public class Converter
    {
        public static TimeSpan ConvertToTimeSpan(string time)
        {
            var formats = new string[] { @"h\:mm", @"H\:mm", @"h\:mm:ss", @"H\:mm:ss" };
            if (!TimeSpan.TryParseExact(time, formats, CultureInfo.CurrentCulture, out var result))
            {
                throw new ArgumentException("Hora infomada tem um formato invalido!", paramName: time);
            }

            return result;
        }

        public static int ConvertToInteger(string integer)
        {
            if(!int.TryParse(integer, out var result))
            {
                throw new ArgumentException("O texto informado não é um valor inteiro válido!", paramName: integer);
            }

            return result;
        }
    }
}
