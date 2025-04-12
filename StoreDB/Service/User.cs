using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Service
{
    public class User
    {
        public User(int userID, string username, string role)
        {
            UserID = userID;
            Username = username;
            Role = role;
        }
        public User()
        {
            
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } // Например: "admin", "manager", "seller"
    }
}
