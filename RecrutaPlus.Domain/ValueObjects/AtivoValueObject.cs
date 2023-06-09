using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.ValueObjects
{
    public class AtivoValueObject : ValueObject
    {
        public static string Offline => "Offline";
        public static string Ativo => "Ativo";


        public static string OfflineCodigo => "0";
        public static string AtivoCodigo => "1";

        public static string GetName(int codigo)
        {
            switch (codigo)
            {
                case 0:
                    return Offline;
                case 1:
                    return Ativo;
                default:
                    return string.Empty;
            }
        }
    }
}
