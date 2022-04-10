using System;
using JobHunt.Api.Models;

namespace JobHunt.Api.Services;

public interface IJobApplicationService {
    public Task<List<JobApplication>> GetAllJobApplications();

    public Task<bool> SubmitJobApplication();

}

public class JobApplicationService : IJobApplicationService {
    public Task<List<JobApplication>> GetAllJobApplications(){
        throw new NotImplementedException();
    }  

    public Task<bool> SubmitJobApplication(){
        throw new NotImplementedException();
    }  
}