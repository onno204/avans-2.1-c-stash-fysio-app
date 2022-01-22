using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IVektisRepository
    {
        IQueryable<Vektis> GetAll();

        Task<Vektis> GetById(int id);

        IEnumerable<Vektis> GetAllList();
    }
}
