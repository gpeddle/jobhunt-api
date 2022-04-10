using JobHunt.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobHunt.Api.Services;

public interface IQuestionService
{
    public Task<List<Question>> GetAllQuestions();
    public Task<Question?> GetQuestionById(string id);
}

public class QuestionService : IQuestionService {
    
    private readonly List<Question> _questions = new List<Question>()
    {
        new Question()
        {
            Id = "id1",
            Text = "Have you ever been convicted of a felony?",
            Answer = "No"
        },
        new Question()
        {
            Id = "id2",
            Text = "Are you authorized to work in the United States?",
            Answer = "Yes"
        },
        new Question()
        {
            Id = "id3",
            Text = "Do you have a valid drivers license?",
            Answer = "Yes"
        },
        new Question()
        {
            Id = "id4",
            Text = "Are you available to work weekends?",
            Answer = "Yes"
        },
        new Question()
        {
            Id = "id5",
            Text = "Are you able to lift 40 pounds?",
            Answer = "Yes"
        },
        new Question()
        {
            Id = "id6",
            Text = "Are you at least 18 years of age?",
            Answer = "Yes"
        },
    };
    public Task<List<Question>> GetAllQuestions()
    {
        return Task.FromResult(_questions);
    }

    public Task<Question?> GetQuestionById(string id)
    {
        var question = _questions.FirstOrDefault(q => q.Id == id);
        return Task.FromResult<Question?>(question);
    }
}