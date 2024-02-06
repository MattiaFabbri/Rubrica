using System.Web;

namespace Rubricawpf
{
    internal class Contatto
    {
        public int idPersona { get; set; }
        public string Valore { get; set; }
        public string Tipo { get; set; }

        public Contatto(int Idpersona,string Valore, string Tipo) { 
            this.idPersona = Idpersona;
            this.Valore = Valore;
            this.Tipo = Tipo;
        }

        public int GetId()
        { return idPersona; }
    }
}
