using Xunit;

using JobHunt.Api;
using JobHunt.Api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using JobHunt.Api.Services;

namespace JobHunt.Api.Tests;

public class TestQuestionService
{

    [Fact]
    public async Task GetAll_Returns_ListOfQuestions()
    {
        // Arrange
        var questionService = new QuestionService();
        
        // Act
        var allQuestions = await questionService.GetAll();
        
        // Assert
        allQuestions.Should().BeOfType<List<Question>>();
    }
    
    [Fact]
    public async Task GetById_ValidId_Returns_Question()
    {
        // Arrange
        var questionService = new QuestionService();
        
        // Act
        var question = await questionService.GetById("id1");
        
        // Assert
        question.Should().BeOfType<Question?>();
    }
    
    [Fact]
    public async Task GetQuestionById_BadId_Returns_Null()
    {
        // Arrange
        var questionService = new QuestionService();
        
        // Act
        var question = await questionService.GetById("SUPERBAD");
        
        // Assert
        question.Should().Be(null);
    }

}