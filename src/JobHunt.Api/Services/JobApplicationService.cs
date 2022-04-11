using System;
using JobHunt.Api.Data;
using JobHunt.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Api.Services;

public interface IJobApplicationService {
    public Task<List<JobApplication>> GetAll();
    
    public Task<JobApplication> GetById(string id);

    public Task<string?> Submit(JobApplication jobApplication);

}

public class JobApplicationService : IJobApplicationService {
    
    private AppDataContext _context;
    private IQuestionService _questionService;

    public JobApplicationService(AppDataContext context, IQuestionService questionService)
    {
        _context = context;
        _questionService = questionService;
    }
    public Task<List<JobApplication>> GetAll()
    {
        var allApplications = _context.JobApplications
                            .Include( a=> a.Answers)
                            .ToList<JobApplication>();
        return Task.FromResult(allApplications);
    }  
    
    public Task<JobApplication> GetById(string id)
    {
        var jobApplication = _context.JobApplications
                            .Include( a=> a.Answers)
                            .SingleOrDefault(o => o.Id == id);
        return Task.FromResult( jobApplication)!;
    }

    public async Task<string?> Submit(JobApplication jobApplication)
    {
        var isValid = true;
       
        if (jobApplication.Answers != null)
        {
            foreach (var a in jobApplication.Answers
                         .Where(a => a.QuestionId != null))
            {
                if (a.QuestionId == null) continue;
                var question = await _questionService.GetById(a.QuestionId);
                if (question?.Answer != a.Answer)
                {
                    isValid = false;
                }
            }
        }

        string? nextId = null;
        if (isValid)
        {
            //nextId = _context.GetNextId();
            _context.JobApplications.Add(jobApplication);
            await _context.SaveChangesAsync();
            
            nextId = jobApplication.Id;
        }

        return nextId;
    }  
}