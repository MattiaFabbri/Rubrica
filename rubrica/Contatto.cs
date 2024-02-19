using System.Collections.Generic;
using System.IO;

namespace Rubricawpf
{
    public class Contatto
    {
        public int idPersona { get; set; }
        public string Valore { get; set; }
        public string Tipo { get; set; }

        public Contatto(int Idpersona, string Valore, string Tipo)
        {
            this.idPersona = Idpersona;
            this.Valore = Valore;
            this.Tipo = Tipo;
        }

        public int GetId()
        {
            return idPersona;
        }
    }

    public class ContattoEmail : Contatto
    {
        public ContattoEmail(int Idpersona, string Valore) : base(Idpersona, Valore, "Email") { }
    }

    public class ContattoWeb : Contatto
    {
        public ContattoWeb(int Idpersona, string Valore) : base(Idpersona, Valore, "Web") { }
    }
    public class ContattoTelefono : Contatto
    {
        public ContattoTelefono(int Idpersona, string Valore) : base(Idpersona, Valore, "Telefono") { }
    }
    public class ContattoFacebook : Contatto
    {
        public ContattoFacebook(int Idpersona, string Valore) : base(Idpersona, Valore, "Facebook") { }
    }
    public class ContattoInstagram : Contatto
    {
        public ContattoInstagram(int Idpersona, string Valore) : base(Idpersona, Valore, "Telefono") { }
    }

    public class Contatti : List<Contatto>
    {
        public Contatti(string filePath)
        {
            string[] dati;
            StreamReader ReaderContatti = new StreamReader(filePath);
            string stringContatto = ReaderContatti.ReadLine();

            do
            {
                dati = stringContatto.Split(";");
                int idPersona;

                if (int.TryParse(dati[0], out idPersona))
                {
                    this.Add(new Contatto(idPersona, dati[1], dati[2]));
                }
                stringContatto = ReaderContatti.ReadLine();
            } while (!ReaderContatti.EndOfStream);
        }
    }

}
