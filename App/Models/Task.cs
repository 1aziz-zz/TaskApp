using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Task : Entity
    {
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }

        [Required]

        public int EmployeeId { get; set; }

        [Required]

        public int ProjectId { get; set; }
    }
}