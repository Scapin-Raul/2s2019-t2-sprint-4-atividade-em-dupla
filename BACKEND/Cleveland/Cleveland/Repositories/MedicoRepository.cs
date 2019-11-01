using Cleveland.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleveland.Repositories
{
    public class MedicoRepository
    {
        public List<MedicoViewModel> Listar ()
        {
            using (ClevelandContext ctx =  new ClevelandContext())
            {
                var y = ctx.Medicos.Include(x => x.EspecialidadeNavigation).ToList();
                var listafinal = new List<MedicoViewModel>();
                foreach (var item in y)
                {
                    var z = new MedicoViewModel();

                    z.Crm = item.Crm;
                    z.Nome = item.Nome;
                    z.DataNascimento = item.DataNascimento;
                    z.Ativo = Convert.ToBoolean(item.Ativo);
                    z.Especialidade = item.EspecialidadeNavigation.Nome;
                    listafinal.Add(z);
                }
                return listafinal;
            }
        } 
    }
}
