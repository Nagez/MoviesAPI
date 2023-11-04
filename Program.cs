using MoviesAPI.Filters;
using MoviesAPI.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using MoviesAPI;
using Microsoft.EntityFrameworkCore;

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

//builder.Services.AddSingleton<IRepository, InMemoryRepository>();
//by using singleton we will get the same instance of the InMemoryRepository class in the lifetime of the application
//in a scope service we will get the same instance in the same http request (this protect the db context of another http request)
//in a transient option we get diffrent instance of the class even in the same http request
//builder.Services.AddTransient<MyActionFilter>();


//configure entity framework core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//addCors needed to work with a web browser
builder.Services.AddCors(options =>
{
    var frontendURL = builder.Configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

//app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
