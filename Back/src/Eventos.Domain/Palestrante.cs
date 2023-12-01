using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Domain
{
    public class Palestrante
    {
        public int id {get; set;}
        public string nome {get; set;}
        public string descricao {get; set;}
        public string imagemURL {get; set;}
        public string telefone {get; set;}
        public string email {get; set;}
        public IEnumerable<RedeSocial> RedesSociais {get; set;}
        public IEnumerable<RedeSocial> RedesSociais {get; set;}
        public IEnumerable<PalestranteEvento> palestrantesEventos {get; set;}

    }
}