using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.Business.Util
{
    public class Utils
    {

        public static string ApenasNumeros(string valor)
        {
            var apenasNumeros = "";

            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                    apenasNumeros += s;
            }
            return apenasNumeros.Trim();
        }

    }
}
