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

        public IEnumerable<Cinemas> GetCinemas()
        {
            _logger.LogInformation("Obteniendo todos los cinemas");
            var result = _dbContext.Cinemas.ToList();
            if(result != null )
            {
                _logger.LogInformation("Obtener Cinemas funciona correctamente");
                return result;
            }
            _logger.LogWarning("No se encontraron cinemas");
            return result;
        }
    }
}
