using Core.Domain;
using Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users.Include(u => u.Appointments)
                .Include(u => u.Comments)
                .Include(u => u.TreatmentHistory)
                .Include(u => u.IntakeUser)
                .Include(u => u.IntakeSuperVisionUser)
                .Include(u => u.MainTherapist);
        }

        public IEnumerable<User> GetAllPatientUsers()
        {
            var users = this.GetAll().Where(u =>
                u.UserType == UserType.Employee || u.UserType == UserType.Student);

            return users.ToList();
        }

        public IEnumerable<User> GetAllTherapistUsers()
        {
            var users = this.GetAll().Where(u =>
                u.UserType == UserType.Therapist || u.UserType == UserType.StudentTherapist);

            return users.ToList();
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await this.GetAll().SingleOrDefaultAsync(u => u.Email.Equals(email.ToLower()));
        }

        public async Task<User> GetById(int id)
        {
            return await this.GetAll().SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
