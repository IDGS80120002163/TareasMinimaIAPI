using Microsoft.EntityFrameworkCore;
using TareasMinimaIAPI.Models;

namespace TareasMinimaIAPI
{
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext>
            options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Creando una colección de objetos Categoría para los datos iniciales.
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c85"),
                Nombre = "Actividades Pendientes",
                Descripcion = "Actividades de Trabajo y/o escuela",
                Peso = 20
            });
            categoriasInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c02"),
                Nombre = "Actividades Personales",
                Descripcion = "Actividades de Carácter Personal",
                Peso = 50
            });

            //Especificando el modelo de categoría FLUENT API
            modelBuilder.Entity<Categoria>(categoria =>
            {
                //Nombre de la tabla
                categoria.ToTable("Categoria");
                //Llave primaria
                categoria.Property(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired
                ().HasMaxLength(150);
                categoria.Property(p => p.Descripcion);

                //Nuevo campo
                categoria.Property(p => p.Peso);

                //Agregamos los datos iniciales 
                categoria.HasData(categoriasInit);
            });

            //Creando una colección de objetos Tarea para los datos iniciales.
            List<Tarea> TareasInit = new List<Tarea>();
            TareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("a50f2609-7f0c-46cc-8352-d2b40065a9f0"),
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c85"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servicios",
                Descripcion = "Pagar servicios de Agua y Luz",
                FechaCreacion = DateTime.Now
            });
            TareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("a50f2609-7f0c-46cc-8352-d2b40065a910"),
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c02"),
                PrioridadTarea = Prioridad.Baja,
                Titulo = "Terminar de ver Película Eso",
                Descripcion = "Terminar de ver en Neflix",
                FechaCreacion = DateTime.Now
            });

            //Especificando el modelo de Tarea FLUENT API
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                //Llave foránea
                tarea.HasOne(p => p.Categoria).WithMany(p =>
                p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired
                ().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                //Campo no mapeado
                tarea.Ignore(p => p.Resumen);

                //Agregamos los datos iniciales
                tarea.HasData(TareasInit);
            });
        }

        //Colección de datos para el modelo de Categoria
        public DbSet<Categoria> Categorias { get; set; }
        //Colección de datos para el modelo de Tarea
        public DbSet<Tarea> Tareas { get; set; }
    }
}
