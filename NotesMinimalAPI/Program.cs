using Microsoft.EntityFrameworkCore; // place this line at the beginning of file.

/*
References: 
- https://www.tutlinks.com/getting-started-with-minimal-web-api-asp-net-core/
- https://www.tutlinks.com/minimal-web-api-with-crud-on-postgresql-dotnet-6/
*/

var builder = WebApplication.CreateBuilder(args);

// Configure JSON logging to the console.
// builder.Logging.AddJsonConsole();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NoteDb>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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


record Note(int id){
    public string text {get;set;} = default!;
    public bool done {get;set;} = default!;
}

class NoteDb: DbContext {
    public NoteDb(DbContextOptions<NoteDb> options): base(options) {

    }
    public DbSet<Note> Notes => Set<Note>();
}