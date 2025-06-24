using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_tareas.Models;

public class Tarea
{
    public Guid Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    [Required]
    public bool State { get; set; }
}