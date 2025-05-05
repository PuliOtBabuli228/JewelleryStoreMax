using StoreDB.ContextDB;
using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMenegment.ViewModel
{
    public class LoginService
    {
        private readonly SQLServerDBContext _context;

        public LoginService(SQLServerDBContext context)
        {
            _context = context;
        }

        public User? Authenticate(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
