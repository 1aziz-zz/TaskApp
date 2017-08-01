using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Project : Entity
    {
        [Required]

        public string Title { get; set; }
        public string Description { get; set; }
        public List<Task> Tasks { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees{ get; set; }
    }
}