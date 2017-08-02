using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Project : Entity
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}