using System;
using System.Collections.Generic;

namespace Cleveland.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }


        public ICollection<Medicos> Medicos { get; set; }
    }
}
