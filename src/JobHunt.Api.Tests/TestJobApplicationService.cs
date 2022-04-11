using System;
using Xunit;
using JobHunt.Api.Models;
using System.Threading.Tasks;
using FluentAssertions;
using System.Collections.Generic;
using JobHunt.Api.Data;
using JobHunt.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Api.Tests;

public class TestJobApplicationService
{

    [Fact]
    public async Task GetAll_Returns_ListOfJobApplications()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var questionService = new QuestionService();
        var jobApplicationService = new JobApplicationService(dbContext, questionService);

        // Act
        var allItems = await jobApplicationService.GetAll();
        
        // Assert
        allItems.Should().BeOfType<List<JobApplication>>();
    }
    
    [Fact]
    public async Task GetById_ValidId_Returns_JobApplication()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var questionService = new QuestionService();
        var jobApplicationService = new JobApplicationService(dbContext, questionService);

        // Act
        var jobApplication = await jobApplicationService.GetById("id1");
        
        // Assert
        jobApplication.Should().BeOfType<JobApplication>();
        jobApplication.Id.Should().Be("id1");
    }
    
    [Fact]
    public async Task GetQuestionById_BadId_Returns_Null()
    {
        // Arrange
        var dbContext = await GetDatabaseContext();
        var questionService = new QuestionService();
        var jobApplicationService = new JobApplicationService(dbContext, questionService);
        
        // Act
        var jobApplication = await jobApplicationService.GetById("SUPERBAD");
        
        // Assert
        jobApplication.Should().Be(null);
    }
    
    [Fact]
    public async Task Submit_ValidData_Returns_New_Id()
    {

        // Arrange
        var dbContext = await GetDatabaseContext();
        var questionService = new QuestionService();
        var sut = new JobApplicationService(dbContext, questionService);
        
        // Act
        var validData = new JobApplication
        {
            Name = "Valid Data",
            Answers = new List<JobApplicationAnswer>()
            {
                new JobApplicationAnswer(){ QuestionId = "id1", Answer = "No"}, // Felony conviction?
                new JobApplicationAnswer(){ QuestionId = "id2", Answer = "Yes"},// Authorized to work?
            }
        };
        var result = await sut.Submit(validData);
        
        // Assert
        result.Should().NotBe(null);
    }
    
    [Fact]
    public async Task Submit_BadData_Returns_Null()
    {

        // Arrange
        var dbContext = await GetDatabaseContext();
        var questionService = new QuestionService();
        var sut = new JobApplicationService(dbContext, questionService);
        
        // Act
        var validData = new JobApplication
        {
            Name = "Bad Data",
            Answers = new List<JobApplicationAnswer>()
            {
                new JobApplicationAnswer(){ QuestionId = "id1", Answer = "Yes"}, // Felony conviction?
                new JobApplicationAnswer(){ QuestionId = "id2", Answer = "No"},// Authorized to work?
            }
        };
        string? result = await sut.Submit(validData);
        
        // Assert
        result.Should().Be(null);
        
    }
    
    private async Task<AppDataContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<AppDataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new AppDataContext(options);
        await dbContext.Database.EnsureCreatedAsync();
        if (await dbContext.JobApplications.AnyAsync() )
        {
            return dbContext;
        }
        
        // initialize with seed data
        for (int i = 1; i <= 10; i++)
        {
            dbContext.JobApplications.Add(new JobApplication()
            {
                Id = $"id{i}",
                Name = $"Name id{i}",
                Answers = new List<JobApplicationAnswer>()
                {
                    new JobApplicationAnswer(){ QuestionId = "id1", Answer = "No"}, // Felony conviction?
                }
            });
            await dbContext.SaveChangesAsync();
        }
        return dbContext;
    }

}