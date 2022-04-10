using System;
using Xunit;

using JobHunt.Api;
using JobHunt.Api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
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
        jobApplication.Should().BeOfType<JobApplication?>();
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
    
    private async Task<DatabaseContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new DatabaseContext(options);
        await dbContext.Database.EnsureCreatedAsync();
        if (await dbContext.JobApplications.CountAsync() > 0)
        {
            return dbContext;
        }
        
        // initialize with seed data
        for (int i = 1; i <= 10; i++)
        {
            dbContext.JobApplications.Add(new JobApplication()
            {
                Id = $"id${i}",
                Name = $"Name id${i}"
            });
            await dbContext.SaveChangesAsync();
        }
        return dbContext;
    }

}