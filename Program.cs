using MoviesAPI.Filters;
using MoviesAPI.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(MyExceptionFilter));
    }); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
//builder.Services.AddAuthorization(JwtBearerDefaults);

builder.Services.AddSingleton<IRepository, InMemoryRepository>();
//by using singleton we will get the same instance of the InMemoryRepository class in the lifetime of the application
//in a scope service we will get the same instance in the same http request (this protect the db context of another http request)
//in a transient option we get diffrent instance of the class even in the same http request
builder.Services.AddTransient<MyActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
