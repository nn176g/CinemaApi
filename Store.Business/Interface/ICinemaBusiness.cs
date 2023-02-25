using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Business.Interface
{
    public interface ICinemaBusiness
    {
        IEnumerable<Cinemas> GetCinemas();
    }
}
