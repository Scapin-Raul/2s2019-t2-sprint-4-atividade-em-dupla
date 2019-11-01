using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleveland.Domains
{
    public class MedicoViewModel
    {
        public int Crm { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public string Especialidade { get; set; }
    }
}
