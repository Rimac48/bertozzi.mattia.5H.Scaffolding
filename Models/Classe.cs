using System;
using System.Collections.Generic;

namespace bertozzi.mattia._5H.Scaffolding.Models
{
    public partial class Classe
    {
        public Classe()
        {
            Studentes = new HashSet<Studente>();
        }

        public long Idclasse { get; set; }
        public string AnnoScolastico { get; set; }
        public long Anno { get; set; }
        public string Sezione { get; set; }

        public virtual ICollection<Studente> Studentes { get; set; }

        public override string ToString()
        {
            return $"ID:{Idclasse} {Anno}^{Sezione} as:{AnnoScolastico}";
        }
    }
}
