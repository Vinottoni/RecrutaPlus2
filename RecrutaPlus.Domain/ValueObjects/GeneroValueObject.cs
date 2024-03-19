using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Domain.ValueObjects
{
    public class GeneroValueObject : ValueObject
    {
        public static string Masculino => "Masculino";
        public static string Feminino => "Feminino";
        public static string LGBTQIAMAIS => "LGBTQIA+";
        public static string PrefinoNaoResponder => "Prefiro não responder";


        public static string MasculinoCodigo => "0";
        public static string FemininoCodigo => "1";
        public static string LGBTQIAMAISCodigo => "2";
        public static string PrefinoNaoResponderCodigo => "3";

        public static string GetName(int codigo)
        {
            switch (codigo)
            {
                case 0:
                    return Masculino;
                case 1:
                    return Feminino;
                case 2:
                    return LGBTQIAMAIS;
                case 3:
                    return PrefinoNaoResponder;
                default:
                    return string.Empty;
            }
        }
    }
}
