using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Interfaces;
using Eventos.Domain;
using Eventos.Persistence;

namespace Eventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEventoPersistence _eventoPersistence;
        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventoPersistence)
        {
            _eventoPersistence = eventoPersistence;
            _geralPersistence = geralPersistence;
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if(await _geralPersistence.SaveChangesAsync()){
                    return await _eventoPersistence.GetEventoByidAsync(model.id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByidAsync(eventoId, false);
                if (evento == null) return null;

                model.id = evento.id;

                _geralPersistence.Update(model);
                if(await _geralPersistence.SaveChangesAsync()){
                    return await _eventoPersistence.GetEventoByidAsync(model.id, false);
                }
                return null;
            
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByidAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento não encontrado");

                _geralPersistence.Delete<Evento>(evento);
                return await _geralPersistence.SaveChangesAsync();
            
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByidAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}