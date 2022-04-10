using JobHunt.Api.Data;
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
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services){
    services.AddTransient<IQuestionService, QuestionService>();
    services.AddTransient<IJobApplicationService, JobApplicationService>();
    services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(databaseName: "JobHuntData"));
}
