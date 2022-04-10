using System;
using JobHunt.Api.Data;
using JobHunt.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Api.Services;

public interface IJobApplicationService {
    public Task<List<JobApplication>> GetAll();
    
    public Task<JobApplication> GetById(string id);

    public Task<bool> Submit();

}

public class JobApplicationService : IJobApplicationService {
    
    private DatabaseContext _context;
    private IQuestionService _questionService;

    public JobApplicationService(DatabaseContext context, IQuestionService questionService)
    {
        _context = context;
        _questionService = questionService;
    }
    public Task<List<JobApplication>> GetAll()
    {
        return Task.FromResult(_context.JobApplications.ToList<JobApplication>());
    }  
    
    public Task<JobApplication> GetById(string id)
    {
        var jobApplication = _context.JobApplications.SingleOrDefault(o => o.Id == id);
        return Task.FromResult( jobApplication)!;
    }  
    
    public Task<bool> Submit(){
        throw new NotImplementedException();
    }  
}