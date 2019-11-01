using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleveland.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cleveland.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        MedicoRepository medicoRepository = new MedicoRepository();

        [HttpGet]
        public IActionResult Listar ()
        {
            return Ok(medicoRepository.Listar());
        }

    }
}