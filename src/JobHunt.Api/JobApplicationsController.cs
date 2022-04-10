using JobHunt.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Api;

[ApiController]
[Route("[controller]")]
public class JobApplicationsController : ControllerBase
{
 
    private readonly IJobApplicationService _jobApplicationService;
    private readonly IQuestionService _questionService;
    public JobApplicationsController(IJobApplicationService jobApplicationService, IQuestionService questionService){
        _jobApplicationService = jobApplicationService;
        _questionService = questionService;
    }

    [HttpGet(Name = "GetAllJobApplications")]
    public async Task<IActionResult> Get()
    {
        var jobApplications = await _jobApplicationService.GetAllJobApplications();
        return Ok(jobApplications);
    }

    [HttpPost(Name = "SubmitJobApplication")]
    public async Task<IActionResult> Post()
    {
        var status = await _jobApplicationService.SubmitJobApplication();

        if (status == false)
        {
            return new BadRequestObjectResult(false);
        }
        return Ok(true); 
    }

}
