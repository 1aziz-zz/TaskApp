using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}