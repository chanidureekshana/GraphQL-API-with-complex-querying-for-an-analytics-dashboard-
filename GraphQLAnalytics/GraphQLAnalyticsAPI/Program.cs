using System.Text;
using GraphQLAnalyticsAPI.Data.DataContext;
using GraphQLAnalyticsAPI.GraphQL.Mutations;
using GraphQLAnalyticsAPI.GraphQL.Queries;
using GraphQLAnalyticsAPI.GraphQL.Types;
using GraphQLAnalyticsAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Database Connection Sql
builder.Services.AddDbContext<SqlDbContext>(options=>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// // Add NoSql Database

// builder.Services.AddSingleton(sp=>{
//     var connectionString = builder.Configuration["MongoDB:ConnectionString"];
//     var databaseName = builder.Configuration["MongoDB:DatabaseName"];
//     return NoSqlDbContext(connectionString , databaseName);
// });

builder.Services.AddSingleton(sp =>
{
    var connectionString = builder.Configuration["MongoDB:ConnectionString"];
    var databaseName = builder.Configuration["MongoDB:nosqlgraphql"];
    
    // Create an instance of NoSqlDbContext using 'new'
    return new NoSqlDbContext(connectionString, databaseName);
});


// object NoSqlDbContext(string? connectionString, string? databaseName)
// {
//     throw new NotImplementedException();
// }

builder.Services.AddStackExchangeRedisCache(options=>{
    options.Configuration= "localhost:1111";
    options.InstanceName = "GraphQl";
});


// Definding Types 

builder.Services
.AddGraphQLServer()
.AddType<UserType>()
.AddType<EventType>()
.AddType<MetricType>();


// // Registering Queries in Schema
// builder.Services
// .AddGraphQLServer()
// .AddQueryType(d => d.Name("Query"))
// .AddType<UserQueries>()
// .AddType<MetricQueries>(); 


// builder.Services
// .AddGraphQLServer()
// .AddType<UserMutations>()
// .AddType<MetricMutations>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

// Configure authentication with JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
});

// Register GraphQL server with authorization
builder.Services.AddGraphQLServerCore()
    .AddAuthorization();


// Add GraphQL server with Hot Chocolate
builder.Services
    .AddGraphQLServer()
    .AddAuthorizationCore()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<UserQueries>()
        .AddTypeExtension<MetricQueries>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<UserMutations>()
        .AddTypeExtension<MetricMutations>();
    // .AddType<UserType>()
    // .AddType<MetricType>();
    // .AddAuthorization()    // Adds authorization directive
    // .AddFiltering()        // Adds support for filtering
    // .AddSorting();         // Adds support for sorting








builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.UseAuthentication();  // Enable JWT authentication
app.UseAuthorization();   // Enable authorization for protected routes

app.MapGraphQL("/graphql");

// app.MapGraphQL();
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();
// builder.Services.AddGraphQLServer().AddQueryType<Query>().AddBananaCakePop(); // Add Banana Cake Pop

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
