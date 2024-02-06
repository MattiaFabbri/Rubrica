namespace Rubricawpf
{
    public class Persona
    {
        public int idPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona(int idPersona, string Nome, string Cognome) {
            this.idPersona = idPersona;
            this.Nome = Nome;
            this.Cognome = Cognome;
        }
        public int GetId()
        { return idPersona; }
    }
   
}
