using Microsoft.Extensions.Logging;
using Store.Data;
using Store.Data.Models;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.CinemaRepository
{
    public  class CinemaRepository : ICinemaRepository
    {
        private readonly ILogger _logger;
        private readonly CinemaDbContext _dbContext;
        public CinemaRepository(CinemaDbContext cinemaDbContext, ILogger<CinemaRepository> logger)
        {
            _dbContext= cinemaDbContext;
            _logger= logger;
        }

        public IEnumerable<Cinemas> GetCinemas(int? id)
        {
            _logger.LogInformation("Obteniendo todos los cinemas");
            List<Cinemas> result;
            if (id != null)
            {
                result = _dbContext.Cinemas.Where(x => x.Id == id).ToList();
            }
            else
            {
                result = _dbContext.Cinemas.ToList();
            }
            if(result != null )
            {
                _logger.LogInformation("Obtener Cinemas funciona correctamente");
                return result;
            }
            _logger.LogWarning("No se encontraron cinemas");
            return result;
        }

        public IEnumerable<Cinemas> GetCinemaAviables()
        {
            _logger.LogInformation("Obteniendo todos los cinemas Disponibles");
            var result = _dbContext.Cinemas.Where(x => (10 >= x.OpenTime.Hour && 13 <= x.CloseTime.Hour)).ToList();
            if (result != null)
            {
                _logger.LogInformation("Obtener Cinemas Disponibles funciona correctamente");
                return result;
            }
            _logger.LogWarning("No se encontraron cinemas");
            return result;

        }

        public IEnumerable<Cinemas> GetCinemasByHours(DateTime starTime, DateTime endTime)
        {
            _logger.LogInformation("Obteniendo todos los cinemas por horas");
            //var result = _dbContext.Cinemas.Where(x => x.OpenTime.Hour >= 10 && x.CloseTime.Hour <= 13).ToList();
            var result = _dbContext.Cinemas.Where(x => (starTime.Hour >= x.OpenTime.Hour && endTime.Hour <= x.CloseTime.Hour)).ToList();
            if (result != null )
            {
                _logger.LogInformation("Obtener Cinemas por hora funciona correctamente");
                return result;
            }
            _logger.LogWarning("No se encontraron cinemas");
            return result;

        }

        public async Task<Cinemas> Add(Cinemas cinema)
        {
            _logger.LogInformation("Creando Nuevo Cinema");
            var tempCinema = NormalizeEntity(cinema);
            _dbContext.Add(tempCinema);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Cinema Creado");
            return tempCinema;
        }


        private Cinemas NormalizeEntity(Cinemas cinema)
        {
            Cinemas tempCinemas = new Cinemas
            {
                Id = cinema.Id,
                Name = cinema.Name,
                address = cinema.address,
                state = cinema.state,
                city = cinema.city,
                OpenTime = cinema.OpenTime,
                CloseTime = cinema.CloseTime
            };
            return tempCinemas;
        }
    }
}
