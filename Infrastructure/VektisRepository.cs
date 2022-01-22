using Core.Domain;
using Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class VektisRepository : IVektisRepository
    {
        private readonly UserDbContext _context;

        public VektisRepository(UserDbContext context)
        {
            _context = context;
        }

        public IQueryable<Vektis> GetAll()
        {
            return _context.VektisList;
        }

        public IEnumerable<Vektis> GetAllList()
        {
            return this.GetAll().ToList();
        }

        public async Task<Vektis> GetById(int id)
        {
            return await this.GetAll().SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
