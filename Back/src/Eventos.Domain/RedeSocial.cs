using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.Domain;

namespace Eventos.Domain
{
    public class RedeSocial
    {
        public int id {get; set;}
        public string nome{get; set;}
        public string URL{get; set;}
        public int? eventoId{get; set;}
        public Evento Evento{get; set;}
        public int? palestranteId{get; set;}
        public Palestrante palestrante{get; set;}
    }
}