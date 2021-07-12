using System;
using System.Collections.Generic;

namespace DapperDemo
{
    public class User
    {
        public int User_Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public List<Address> Address { get; set; }
        public List<Community> Community { get; set; }
    }
}