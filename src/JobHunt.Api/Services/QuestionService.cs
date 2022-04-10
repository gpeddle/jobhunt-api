using JobHunt.Api.Models;

namespace JobHunt.Api.Services;

public interface IQuestionService
{
    public Task<List<Question>> GetAllQuestions();
}

public class QuestionService : IQuestionService {
    public Task<List<Question>> GetAllQuestions(){
        throw new NotImplementedException();
    }
}