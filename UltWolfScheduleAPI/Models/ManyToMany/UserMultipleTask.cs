using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltWolfScheduleAPI.Models
{
    public class UserMultipleTask
    {
        public int MultipleTaskId { get; set; }
        public MultipleTask task { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
