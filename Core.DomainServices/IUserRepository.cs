using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();

        IEnumerable<User> GetAllTherapistUsers();
        IEnumerable<User> GetAllStudentTherapistUsers();

        IEnumerable<User> GetAllPatientUsers();

        Task<User> GetById(int id);

        Task<User> GetByEmail(string email);

        Task Add(User user);

        Task Update(User user);
    }
}
