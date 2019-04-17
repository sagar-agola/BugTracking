using BugTracking.Business.Contracts.Repositories.Users;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System;

namespace BugTracking.Business.Dal.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public int EmployeeCount()
        {
            return Context.Users
                .Where(user => user.IsActive)
                .Count();
        }

        public User GetById(int id)
        {
            return Context.Users
                .Where(user => user.Id == id)
                .Include(user => user.User_Roles)
                .FirstOrDefault();
        }

        List<User> IUserRepository.GetAll()
        {
            return Context.Users.Where(user => user.IsActive)
                .Include(user => user.User_Roles)
                .Include(user => user.Project_Developers)
                .Include(user => user.Bugs).ToList();
        }

        void IUserRepository.Delete(User user)
        {
            user.IsActive = false;
            Update(user);
        }

        public List<User> GetFreeEmployees()
        {
            return Context.Users
                .Where(user => user.Project_Developers.Count == 0 && user.IsActive)
                .ToList();
        }

        public int Authenticate(string email, string password)
        {
            try
            {
                return Context.Users
                    .Where(u => u.Email == email && u.Password == password)
                    .FirstOrDefault()
                    .Id;
            }
            catch(Exception)
            {
                return 0;
            }
        }
    }
}
