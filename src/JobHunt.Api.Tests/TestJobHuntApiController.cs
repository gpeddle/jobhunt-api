using Xunit;
using JobHunt.Api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using JobHunt.Api.Services;

namespace JobHunt.Api.Tests;

public class TestJobHuntApiController
{
    [Fact]
     public async Task Get_Returns_Status_200()
    {
        // Arrange
        var mockJobApplicationService = new Mock<IJobApplicationService>();
        mockJobApplicationService
            .Setup(service => service.GetAll())
            .ReturnsAsync(new List<JobApplication>());
        var questionService = new QuestionService();
        var sut = new JobHuntApiController(
            mockJobApplicationService.Object,
            questionService
        );

        // Act
        var result = (OkObjectResult)  await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_Invokes_JobApplicationService_Once()
    {
        // Arrange
        var mockJobApplicationService = new Mock<IJobApplicationService>();
        mockJobApplicationService
            .Setup(service => service.GetAll())
            .ReturnsAsync(new List<JobApplication>());
        var questionService = new QuestionService();
        var sut = new JobHuntApiController(
            mockJobApplicationService.Object,
            questionService
        );

        // Act
        var result = (OkObjectResult)  await sut.Get();
        
        // Assert
        mockJobApplicationService.Verify(
            service => service.GetAll(),
            Times.Once()
        );

    }

    [Fact]
    public async Task Get_OnSuccess_Returns_ListOfJobApplications()
    {
        // Arrange
        var mockList = new List<JobApplication>(){
            new JobApplication { Name = "Job Seeker 1"},
            new JobApplication { Name = "Job Seeker 2"},
        };

        var mockJobApplicationService = new Mock<IJobApplicationService>();
        mockJobApplicationService
            .Setup(service => service.GetAll())
            .Returns(Task.FromResult(mockList));
        var questionService = new QuestionService();
        var sut = new JobHuntApiController(
            mockJobApplicationService.Object,
            questionService
        );

        // Act
        var result = (OkObjectResult)  await sut.Get();
        
        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var data = result.Value as List<JobApplication>;
        data.Should().BeOfType<List<JobApplication>>();

    }

    [Fact]
    public async Task Post_OnAccepted_Returns_Status_200()
    {

        // Arrange
        var mockJobApplicationService = new Mock<IJobApplicationService>();
        mockJobApplicationService
            .Setup(service => service.Submit())
            .Returns(Task.FromResult(true));
        var questionService = new QuestionService();
        var sut = new JobHuntApiController(
            mockJobApplicationService.Object,
            questionService
        );

        // Act
        var validData = new JobApplication { Name = "Job Seeker 1"};
        var result = (OkObjectResult)await sut.Post();

        // Assert
        result.StatusCode.Should().Be(200);

    }
    [Fact]
    public async Task Post_OnRejected_Returns_Status_400()
    {

        // Arrange
        var mockJobApplicationService = new Mock<IJobApplicationService>();
        mockJobApplicationService
            .Setup(service => service.Submit())
            .Returns(Task.FromResult(false));

        var questionService = new QuestionService();
        var sut = new JobHuntApiController(
            mockJobApplicationService.Object,
            questionService
        );
        // Act
        var badData = new JobApplication { Name = "Job Seeker 1"};
        var result = (BadRequestObjectResult) await sut.Post();
      
        // Assert
        result.StatusCode.Should().Be(400);

    }
    
}