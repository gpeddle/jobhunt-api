using JobHunt.Api.Data;
using JobHunt.Api.Models;
using JobHunt.Api.Services;

using Microsoft.EntityFrameworkCore ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobHuntApi v1")
        );
}

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services){
    services.AddTransient<IQuestionService, QuestionService>();
    services.AddTransient<IJobApplicationService, JobApplicationService>();
    services.AddDbContext<AppDataContext>(options => options.UseInMemoryDatabase(databaseName: "JobHuntData"));
}



