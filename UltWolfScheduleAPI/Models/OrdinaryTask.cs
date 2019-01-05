using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltWolfScheduleAPI.Models
{
    public class OrdinaryTask:Abstracts.AbstractTask
    { 
        public User User { get; set; }
    }
}
