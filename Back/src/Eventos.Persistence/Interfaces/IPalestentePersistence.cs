using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence
{
    public interface IPalestrantePersistence
    {
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByidAsync(int palestranteId, bool includeEventos);

    }
}