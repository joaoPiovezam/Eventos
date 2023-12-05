using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantePersistence
    {
        private readonly EventosContext _context;
        public PalestrantesPersistence(EventosContext context)
        {
            _context = context;
        }
       

        public async Task<Palestrante> GetPalestranteByidAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

            if (includeEventos){
                query = query.Include(p => p.palestrantesEventos).ThenInclude(pe => pe.evento);
            }
            query = query.OrderBy(p => p.id).Where(p => p.id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

            if (includeEventos){
                query = query.Include(p => p.palestrantesEventos).ThenInclude(pe => pe.evento);
            }
            query = query.OrderBy(p => p.id).Where(p => p.nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.Include(p => p.RedesSociais);

            if (includeEventos){
                query = query.Include(p => p.palestrantesEventos).ThenInclude(pe => pe.evento);
            }
            query = query.OrderBy(p => p.id);

            return await query.ToArrayAsync();
        }

        


    }
}