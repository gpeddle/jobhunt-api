using JobHunt.Api.Models;
using JobHunt.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Api;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationController : ControllerBase
{
 
    private readonly IJobApplicationService _jobApplicationService;
    private readonly IQuestionService _questionService;
    public JobApplicationController( IJobApplicationService jobApplicationService, 
                              IQuestionService questionService){
        _jobApplicationService = jobApplicationService;
        _questionService = questionService;
    }
    
    [HttpGet(Name = "GetAllJobApplications")]
    public async Task<IActionResult> GetAllJobApplications()
    {
        var jobApplications = await _jobApplicationService.GetAll();
        return Ok(jobApplications);
    }
    
    [HttpPost(Name = "SubmitJobApplication")]
    public async Task<IActionResult> SubmitJobApplication([Bind("Name,Answers")] JobApplication jobApplication)
    {
        var newId = await _jobApplicationService.Submit(jobApplication);
        if (String.IsNullOrEmpty(newId))
        {
            return BadRequest("All answers must be valid");
        }
        return Ok(newId); 
    }

}
