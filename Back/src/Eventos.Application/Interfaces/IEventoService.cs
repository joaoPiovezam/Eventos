using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEventos(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);       
    }
}