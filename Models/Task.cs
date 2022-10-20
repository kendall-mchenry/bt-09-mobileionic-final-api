using System.ComponentModel.DataAnnotations;

namespace final_task_api.Models;

public class Task 
{
    public int TaskId { get; set; }

    [Required]
    public string? TaskTitle { get; set; }

    [Required]
    public bool TaskCompleted { get; set; }
}
