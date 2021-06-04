using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova6_CatalinaDorneanu
{
    class Agente:Persona
    {
        //L’agente ha le seguenti caratteristiche:
        //- Nome
        //- Cognome
        //- Codice fiscale
        //- Area geografica
        //- Anno di inizio attività
        public string AreaGeografica { get; set; }
        public int AnnoInizio { get; set; }
        public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int annoInizio)
            :base(nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoInizio = annoInizio;
        }
    }
}
