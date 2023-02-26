using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Business.Interface;
using Store.Data.Models;
using Store.Repository.Interfaces;

namespace Store.Business.StoreBusiness
{
    //private readonly
    public class CinemaBusiness : ICinemaBusiness
    {
        private readonly ICinemaRepository _cinemaRepository;
        public CinemaBusiness(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository= cinemaRepository;
        }
        public IEnumerable<Cinemas> GetCinemas(int? id)
        {
            return _cinemaRepository.GetCinemas(id);
        }

        public IEnumerable<Cinemas> GetCinemaAviables()
        {
            return _cinemaRepository.GetCinemaAviables();
        }
        public IEnumerable<Cinemas> GetCinemasByHours(int starTime, int endTime)
        {
            return _cinemaRepository.GetCinemasByHours(starTime, endTime);
        }

        public async Task<Cinemas> Insert(Cinemas model)
        {
            return await _cinemaRepository.Add(model);
        }
    }
}
