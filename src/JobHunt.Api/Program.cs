using JobHunt.Api.Data;
using JobHunt.Api.Models;
using JobHunt.Api.Services;

using Microsoft.EntityFrameworkCore ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);
InitSeedData();

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
    services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(databaseName: "JobHuntData"));
}

async void InitSeedData()
{
    var options = new DbContextOptionsBuilder<DatabaseContext>()
        .UseInMemoryDatabase(databaseName: "JobHuntData")
        .Options;
    var dbContext = new DatabaseContext(options);
    await dbContext.Database.EnsureCreatedAsync();
    if (await dbContext.JobApplications.AnyAsync() )
    {
        return;
    }
        
    // initialize with seed data
    for (int i = 1; i <= 3; i++)
    {
        dbContext.JobApplications.Add(new JobApplication()
        {
            Id = $"id{i}",
            Name = $"Name id{i}",
            
        });
        await dbContext.SaveChangesAsync();
    }
    return;
}

