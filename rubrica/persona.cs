using System.Collections.Generic;
using System.IO;
using System;

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

    public class Persone : List<Persona>
    {
        public Persone(string filePath)
        {
            string[] dati;
            StreamReader ReaderPersone = new StreamReader(filePath);
            string stringPersona = ReaderPersone.ReadLine();

            do
            {
                dati = stringPersona.Split(";");
                this.Add(new Persona(Convert.ToInt32(dati[0]), dati[1], dati[2]));
                stringPersona = ReaderPersone.ReadLine();
            } while (!ReaderPersone.EndOfStream);
        }
    }

}
