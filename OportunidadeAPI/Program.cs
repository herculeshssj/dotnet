using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OportunidadeDb>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Urls.Add("http://0.0.0.0:7242");

/* GET - /concursos - Todos os concursos */
app.MapGet("/concursos", async (OportunidadeDb db) =>  {
    return await db.concursos.ToListAsync();
});

/* GET - /concurso/{id} - Concurso pelo ID */
app.MapGet("/concurso/{id:guid}", async(string id, OportunidadeDb db)=> {
    return await db.concursos.FindAsync(id) is Concurso c ? Results.Ok(c) : Results.NotFound();
});

/* POST - /concurso - Novo concurso */
/* PUT - /concurso/{id} - Alterar concurso */
/* DELETE - /concurso/{id} - Excluir concurso */

/* GET - /concursos/arquivado - Todos os concursos arquivados */
app.MapGet("/concursos/arquivado", async (OportunidadeDb db) =>  {
    return await db.concursos.Where(x => x.arquivado.Equals(true)).ToListAsync();
});

/* GET - /concursos/ativo - Todos os concursos ativos */
app.MapGet("/concursos/ativo", async (OportunidadeDb db) =>  {
    return await db.concursos.Where(x => x.arquivado.Equals(false)).ToListAsync();
});

/* GET - /concursos/estado/{uf} - Todos os concursos de um determinado estado */
app.MapGet("/concursos/estado/{uf:alpha}", async (string uf, OportunidadeDb db) =>  {
    Console.Write("Hello");
    return await db.concursos.Where(x => x.uf.Equals(uf)).ToListAsync();
});
/* GET - /concurso/ativo/{uf} - todos os concursos ativos de um determinado estado */
app.MapGet("/concursos/ativo/{uf:alpha}", async (string uf, OportunidadeDb db) =>  {
    return await db.concursos.Where(x => x.uf.Equals(uf) && x.arquivado.Equals(false)).ToListAsync();
});

/* GET - /concursos/arquivado/{uf} - todos os concursos arquivados de um determinado estado */
app.MapGet("/concursos/arquivado/{uf:alpha}", async (string uf, OportunidadeDb db) =>  {
    return await db.concursos.Where(x => x.uf.Equals(uf) && x.arquivado.Equals(true)).ToListAsync();
});

/* PUT - /concurso/arquivar/{id} - arquivar o concurso selecionado */ 
app.MapPut("/concurso/arquivar/{id:guid}", async(string id, OportunidadeDb db)=>
{
    var c = await db.concursos.FindAsync(id);
    
    if (c is null) return Results.NotFound();

    if (c.arquivado) return Results.NotFound();

    // encontrado, seta o concurso como arquivado
    c.arquivado = true;

    await db.SaveChangesAsync();
    return Results.Ok(c);
});

/*
app.MapPost("/notes/", async(Note n, NoteDb db)=> {
    db.Notes.Add(n);
    await db.SaveChangesAsync();

    return Results.Created($"/notes/{n.id}", n);
});

app.MapDelete("/notes/{id:int}", async(int id, NoteDb db)=>{

    var note = await db.Notes.FindAsync(id);
    if (note is not null){
        db.Notes.Remove(note);
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});

*/
await app.RunAsync();


record Concurso(string id){
    public string titulo {get;set;} = default!;
    public string descricao {get;set;} = default!;
    public string link {get;set;} = default!;
    public string uf {get;set;} = default!;
    public string hash {get;set;} = default!;
    [Column("datacadastro", TypeName ="date")]
    public DateTime dataCadastro {get;set;} = default!;
    public string? cargos {get;set;}
    public double? salario {get;set;}
    [Column("nivelescolaridade")]
    public string? nivelEscolaridade {get;set;}
    public int? vagas {get; set;}
    [Column("vagascargossalarios")]
    public string? vagasCargosSalarios {get;set;}
    [Column("periodoinscricao")]
    public string? periodoInscricao {get;set;}
    [Column("dataterminoinscricao")]
    public DateTime? dataTerminoInscricao {get;set;}
    public bool arquivado {get;set;} = default!;
}

/*
Método toString(), para gerar o hash
public String toString() {
        return this.titulo + "\n\r" + this.descricao + "\n\r" + "UF: " + this.uf + "\n\r" + this.link + "\n\r" + this.vagasCargosSalarios + "\n\r" + this.periodoInscricao;
    }
*/

class OportunidadeDb: DbContext {
    public OportunidadeDb(DbContextOptions<OportunidadeDb> options): base(options) {

    }
    public DbSet<Concurso> concursos => Set<Concurso>();
}
    