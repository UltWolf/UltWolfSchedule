using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltWolfScheduleAPI.Models.Abstracts;
using UltWolfScheduleAPI.Models.ManyToMany;

namespace UltWolfScheduleAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  Username { get; set; }
        public string  Password { get; set; }
        public string Email { get; set; } 
        public ICollection< OrdinaryTask> Task { get; } = new List< OrdinaryTask>();
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
