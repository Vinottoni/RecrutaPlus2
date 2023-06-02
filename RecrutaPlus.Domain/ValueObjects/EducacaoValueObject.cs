using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.ValueObjects
{
    public class EducacaoValueObject : ValueObject
    {
        public static string EnsinoFundamental => "Ensino Fundamental";
        public static string EnsinoFundamentalIncompleto => "Ensino Fundamental Incompleto";
        public static string EnsinoMedio => "Ensino Medio";
        public static string EnsinoMedioIncompleto => "Ensino Medio Incompleto";
        public static string EnsinoSuperior => "Ensino Superior";
        public static string EnsinoSuperiorIncompleto => "Ensino Superior Incompleto";


        public static string EnsinoFundamentalCodigo => "0";
        public static string EnsinoFundamentalIncompletoCodigo => "1";
        public static string EnsinoMedioCodigo => "2";
        public static string EnsinoMedioIncompletoCodigo => "3";
        public static string EnsinoSuperiorCodigo => "4";
        public static string EnsinoSuperiorIncompletoCodigo => "5";

        public static string GetName(int codigo)
        {
            switch (codigo)
            {
                case 0:
                    return EnsinoFundamental;
                case 1:
                    return EnsinoFundamentalIncompleto;
                case 2:
                    return EnsinoMedio;
                case 3:
                    return EnsinoMedioIncompleto;
                case 4:
                    return EnsinoSuperior;
                case 5:
                    return EnsinoSuperiorIncompleto;
                default:
                    return string.Empty;
            }
        }
    }
}
