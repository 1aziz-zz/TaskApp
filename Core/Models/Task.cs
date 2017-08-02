using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Task : Entity
    {
        [Required]

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }

    }
}