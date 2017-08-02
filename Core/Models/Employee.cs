using System.Collections.Generic;
using Core.Models;

namespace Core.Models
{
    public class Employee : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public List<Task> Tasks { get; set; }
    }
}