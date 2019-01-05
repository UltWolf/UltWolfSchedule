using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UltWolfScheduleAPI.Models
{
    public class MultipleTask:Abstracts.AbstractTask
    {
        [ForeignKey("User")]
        public List<User> user { get; set; }
    }
}
