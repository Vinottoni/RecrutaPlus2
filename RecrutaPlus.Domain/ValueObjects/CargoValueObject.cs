using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.ValueObjects
{
    public class CargoValueObject : ValueObject
    {
        public static string CEO => "CEO";
        public static string Presidente => "Presidente";
        public static string Diretor => "Diretor";
        public static string CoordenadorSupervisor => "Coordenador / Supervisor";
        public static string Analista => "Analista (junior, pleno , senior)";
        public static string Assistente => "Assistente";
        public static string Auxiliar => "Auxiliar";


        public static string CEOCodigo => "1";
        public static string PresidenteCodigo => "2";
        public static string DiretorCodigo => "3";
        public static string CoordenadorSupervisorCodigo => "4";
        public static string PrefinoNaoResponderCodigo => "5";
        public static string AssistenteCodigo => "6";
        public static string AuxiliarCodigo => "7";

        public static string GetName(int codigo)
        {
            switch (codigo)
            {
                case 1:
                    return CEO;
                case 2:
                    return Presidente;
                case 3:
                    return Diretor;
                case 4:
                    return CoordenadorSupervisor;
                case 5:
                    return Analista;
                case 6:
                    return Assistente;
                case 7:
                    return Auxiliar;
                default:
                    return string.Empty;
            }
        }
    }
}
