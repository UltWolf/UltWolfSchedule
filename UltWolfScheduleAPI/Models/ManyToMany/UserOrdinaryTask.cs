using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltWolfScheduleAPI.Models.ManyToMany
{
    public class UserOrdinaryTask
    {
        public int OrdinaryTaskId { get; set; }
        public OrdinaryTask task { get; set; }
        public int UserId { get; set; }
        public User User  { get; set; }
    }
}
