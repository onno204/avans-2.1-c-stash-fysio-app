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
            return _context.Vektis.Include(u => u.Appointments)
                .Include(u => u.Comments)
                .Include(u => u.TreatmentHistory)
                .Include(u => u.IntakeUser)
                .Include(u => u.IntakeSuperVisionUser)
                .Include(u => u.MainTherapist);
        }
        public async Task<Vektis> GetById(int id)
        {
            return await this.GetAll().SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
