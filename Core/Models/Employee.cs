using System.Collections.Generic;

namespace Core.Models
{
    public class Employee : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public List<Task> Tasks { get; set; }
    }
}