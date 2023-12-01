using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Domain
{
    public class Lote
    {
        public int id {get; set;}
        public string nome {get; set;}
        public decimal preco {get; set;}
        public DateTime? dataInicio {get; set;}
        public DateTime? dataFim {get; set;}
        public int qtd {get; set;}
        public int eventoId {get; set;}
        public Evento Evento {get; set;}
    }
}