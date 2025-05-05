using StoreDB.ContextDB;
using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMenegment.ViewModel
{
    public class RegistrationService
    {
        private readonly SQLServerDBContext _context;

        public RegistrationService(SQLServerDBContext context)
        {
            _context = context;
        }

        public bool Register(string username, string role)
        {
            if (_context.Users.Any(u => u.Username == username))
                return false; // Пользователь уже существует

            var newUser = new User
            {
                Username = username,
                Role = role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return true;
        }
    }
}
