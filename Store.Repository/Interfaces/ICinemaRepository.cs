using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface ICinemaRepository
    {
        IEnumerable<Cinemas> GetCinemas(int? id);
        IEnumerable<Cinemas> GetCinemaAviables();
        IEnumerable<Cinemas> GetCinemasByHours(int starTime, int endTime);
        Task<Cinemas> Add(Cinemas cinema);
    }
}
