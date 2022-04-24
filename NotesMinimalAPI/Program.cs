using Microsoft.EntityFrameworkCore; // place this line at the beginning of file.

/*
References: 
- https://www.tutlinks.com/getting-started-with-minimal-web-api-asp-net-core/
- https://www.tutlinks.com/minimal-web-api-with-crud-on-postgresql-dotnet-6/
*/

/* API implementation

HTTP VERB   ENDPOINT        STATUS CODE(S)      	DESCRIPTION
POST	    /notes	        201 Created 	        Creates a Note
GET	        /notes/{id:int} 200 OK, 404 Not Found   Read a Note given its id
GET	        /notes          200 OK                  Retrieves all Notes
PUT	        /notes/{id:int} 200 OK, 404 Not Found,
                            400 Bad Request	        Updates a Note given its id
DELETE	    /notes/{id:int} 204 No Content          Deletes a Note given its id

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

app.MapPost("/notes/", async(Note n, NoteDb db)=> {
    db.Notes.Add(n);
    await db.SaveChangesAsync();

    return Results.Created($"/notes/{n.id}", n);
});

app.MapGet("/notes/{id:int}", async(int id, NoteDb db)=> {
    return await db.Notes.FindAsync(id)
            is Note n
                ? Results.Ok(n)
                : Results.NotFound();
});

app.MapGet("/notes", async (NoteDb db) =>  {
    return await db.Notes.ToListAsync();
});

app.MapPut("/notes/{id:int}", async(int id, Note n, NoteDb db)=>
{
    if (n.id != id)
    {
        return Results.BadRequest();
    }

    var note = await db.Notes.FindAsync(id);
    
    if (note is null) return Results.NotFound();

    //found, so update with incoming note n.
    note.text = n.text;
    note.done = n.done;
    await db.SaveChangesAsync();
    return Results.Ok(note);
});

app.MapDelete("/notes/{id:int}", async(int id, NoteDb db)=>{

    var note = await db.Notes.FindAsync(id);
    if (note is not null){
        db.Notes.Remove(note);
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});

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