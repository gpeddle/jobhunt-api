using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Api;

[ApiController]
[Route("[controller]")]
public class JobApplicationsController : ControllerBase
{
 
    private readonly IJobApplicationService _jobApplicationService;
    public JobApplicationsController(IJobApplicationService jobApplicationService){
        _jobApplicationService = jobApplicationService;
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
