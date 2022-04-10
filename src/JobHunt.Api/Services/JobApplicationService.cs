using System;
using JobHunt.Api.Data;
using JobHunt.Api.Models;

namespace JobHunt.Api.Services;

public interface IJobApplicationService {
    public Task<List<JobApplication>> GetAll();
    
    public Task<JobApplication> GetById(string id);

    public Task<bool> Submit();

}

public class JobApplicationService : IJobApplicationService {
    
    private DatabaseContext _context;
    private QuestionService _questionService;

    public JobApplicationService(DatabaseContext context, QuestionService questionService)
    {
        _context = context;
        _questionService = questionService;
    }
    public Task<List<JobApplication>> GetAll(){
        throw new NotImplementedException();
    }  
    
    public Task<JobApplication> GetById(string id){
        throw new NotImplementedException();
    }  
    
    public Task<bool> Submit(){
        throw new NotImplementedException();
    }  
}