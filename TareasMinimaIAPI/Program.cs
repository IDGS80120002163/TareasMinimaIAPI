using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMinimaIAPI;
using TareasMinimaIAPI.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

//Agregando la configuración para una BD en SQLServer
builder.Services.AddSqlServer<TareasContext>
    (builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

//Agregando la configuración para un BD en Memoria

app.MapGet("/", () => "Hello World!");

//Agregando un endpoint
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

//Creando un endpoint para consultar todas las tareas
app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas);
});

//Creando un endpoint para consultar todas las tareas con una prioridad baja
app.MapGet("/api/tareasbajacat", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == TareasMinimaIAPI.Models.Prioridad.Baja));
});

//End point para Insertar una nueva tarea POST.
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    //Agregamos la nueva tarea a la tabla.
    await dbContext.AddAsync(tarea);

    //Guardamos los cambios
    await dbContext.SaveChangesAsync();

    return Results.Ok($"La tarea: {tarea.Titulo}, se registró exitosamente");
});

//End point para Modificar una tarea existente PUT.
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    //Buscamos la tarea actual con base al id
    var tareaActual = await dbContext.Tareas.FindAsync(id);

    if (tareaActual != null)
    {
        //Si la tarea existe modificamos sus datos.
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok($"La tarea: {tareaActual.Titulo}, se modificó exitosamente");
    }

    return Results.NotFound();
});

//End point para Eliminar una tarea existente DELETE.
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    //Buscamos la tarea actual con base al id
    var tareaActual = await dbContext.Tareas.FindAsync(id);

    if (tareaActual != null)
    {
        //Si la tarea existe la eliminamos de la BD.
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok($"La tarea: {tareaActual.Titulo}, se eliminó exitosamente");
    }

    return Results.NotFound();
});

app.Run();
