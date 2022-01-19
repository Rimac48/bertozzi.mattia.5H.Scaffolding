using System;
using System.Collections.Generic;

namespace bertozzi.mattia._5H.Scaffolding.Models
{
    public partial class Materium
    {
        public long IdMateria { get; set; }
        public string Nome { get; set; }
        public long? FkIdclasse { get; set; }
    }
}
