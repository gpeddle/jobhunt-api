using Xunit;

using JobHunt.Api;
using JobHunt.Api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using System.Collections.Generic;

namespace JobHunt.Api.Tests;

public class Test_JobApplicationsController
{
    [Fact]
     public async Task Get_Returns_Status_200()
    {
        // Arrange
        var mockJobApplicationService = new Mock<IJobApplicationService>();
        mockJobApplicationService
            .Setup(service => service.GetAllJobApplications())
            .ReturnsAsync(new List<JobApplication>());
        var sut = new JobApplicationsController(mockJobApplicationService.Object);

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
            .Setup(service => service.GetAllJobApplications())
            .ReturnsAsync(new List<JobApplication>());
        var sut = new JobApplicationsController(mockJobApplicationService.Object);

        // Act
        var result = (OkObjectResult)  await sut.Get();
        
        // Assert
        mockJobApplicationService.Verify(
            service => service.GetAllJobApplications(),
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
            .Setup(service => service.GetAllJobApplications())
            .Returns(Task.FromResult(mockList));
        var sut = new JobApplicationsController(mockJobApplicationService.Object);

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
            .Setup(service => service.SubmitJobApplication())
            .Returns(Task.FromResult(true));
        var sut = new JobApplicationsController(mockJobApplicationService.Object);

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
            .Setup(service => service.SubmitJobApplication())
            .Returns(Task.FromResult(false));
        var sut = new JobApplicationsController(mockJobApplicationService.Object);

        // Act
        var badData = new JobApplication { Name = "Job Seeker 1"};
        var result = (BadRequestObjectResult) await sut.Post();
      
        // Assert
        result.StatusCode.Should().Be(400);

    }

}