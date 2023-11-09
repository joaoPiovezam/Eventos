using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento[]{
                new Evento() {
                    eventoId = 1,
                    tema = "Angular e .NEt",
                    local = "CG",
                    qtdPessoas = 250,
                    lote = "1",
                    dataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    imagemURL = "foto.png"
                }
            };
        }

        [HttpPost]
        public string Post()
        {
            return "Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Delete = {id}";
        }
    }
}
