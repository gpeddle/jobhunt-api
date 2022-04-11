using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Api.Models;

public class JobApplicationAnswer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; } 
    public string? QuestionId { get; set; }
    public string? Answer { get; set; }
}