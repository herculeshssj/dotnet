/*
Reference: https://www.tutlinks.com/getting-started-with-minimal-web-api-asp-net-core/
*/

var builder = WebApplication.CreateBuilder(args);

// Configure JSON logging to the console.
// builder.Logging.AddJsonConsole();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Setting the application ports
// Application ports are set on appsettings.json
// app.Urls.Add("https://0.0.0.0:7243");
// app.Urls.Add("http://0.0.0.0:7242");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Welcome to Notes API!");

await app.RunAsync();