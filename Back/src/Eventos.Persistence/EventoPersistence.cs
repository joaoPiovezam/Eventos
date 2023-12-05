using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence
{
    public class EventoPersistence : IEventoPersistence
    {
        private readonly EventosContext _context;
        public EventoPersistence(EventosContext context)
        {
            _context = context;
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.lotes).Include(e => e.redes);

            if (includePalestrantes){
                query = query.Include(e => e.palestrantesEventos).ThenInclude(pe => pe.palestrante);
            }
            query = query.AsNoTracking().OrderBy(e => e.id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByidAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.lotes).Include(e => e.redes);

            if (includePalestrantes){
                query = query.Include(e => e.palestrantesEventos).ThenInclude(pe => pe.palestrante);
            }
            query = query.AsNoTracking().OrderBy(e => e.id).Where(e => e.id == eventoId);

            return await query.FirstOrDefaultAsync();
        }



        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.lotes).Include(e => e.redes);

            if (includePalestrantes){
                query = query.Include(e => e.palestrantesEventos).ThenInclude(pe => pe.palestrante);
            }
            query = query.AsNoTracking().OrderBy(e => e.id).Where(e => e.tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }


    }
}