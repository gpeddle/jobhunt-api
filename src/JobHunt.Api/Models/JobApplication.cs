using System.ComponentModel.DataAnnotations.Schema;

namespace JobHunt.Api.Models;

public class JobApplication
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public List<JobApplicationAnswer>? Answers { get; set; }
    
}
