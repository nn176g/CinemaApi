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
        public IEnumerable<Cinemas> GetCinemas()
        {
            return _cinemaRepository.GetCinemas();
        }
    }
}
