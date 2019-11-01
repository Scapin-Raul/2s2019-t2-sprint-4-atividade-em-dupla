using System;
using System.Collections.Generic;

namespace Cleveland.Domains
{
    public partial class Medicos
    {
        public int Crm { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool? Ativo { get; set; }
        public int? Especialidade { get; set; }
        public Especialidade EspecialidadeNavigation { get; set; }
    }
}
