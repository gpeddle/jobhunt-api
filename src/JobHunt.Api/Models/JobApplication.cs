namespace JobHunt.Api.Models;

public class JobApplication
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public List<JobApplicationAnswer>? Answers { get; set; }
    
}
