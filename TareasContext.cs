using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public class TareasContext: DbContext{

    public DbSet<Tarea> Tareas {get;set;}
    
    public DbSet<Categoria> Categorias { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}


   protected override void OnModelCreating(ModelBuilder modelBuilder){ //Se crea el metodo con el parametro de tipo ModelBuilder con el que nos comunicaremos con fuent api.
    List<Categoria> categoriaInit = new()
    {
        new Categoria()
        {
            CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
            Nombre = "Cat1"
        }
    };
        modelBuilder.Entity<Categoria>(category =>{ // Un modelBuilder.Entity<Model> por cada modelo.
            category.ToTable("Category"); // Nombre de la tabla
            category.HasKey(pk => pk.CategoriaId); // Primary Key
            category.Property(prop => prop.Nombre).HasMaxLength(150).IsRequired(); //Constraints a campo nombre.
            category.Property(prop => prop.Descripcion).IsRequired(false); //Llamada simple
            category.Ignore(prop => prop.Resumen);
            category.HasData(categoriaInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea(){TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"),
        Nombre= "Frandel",
        Apellido= "Corporan",
        Descripcion= "Testing EF",
        PrioridadTarea = Prioridad.Alta,
        CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef")
        });
        modelBuilder.Entity<Tarea>(task =>{
            task.ToTable("Task");
            task.HasKey(pk => pk.TareaId);
            task.HasOne(prop => prop.Categoria).WithMany(prop => prop.Tareas).HasForeignKey(fk => fk.CategoriaId);
            task.Property(prop => prop.Nombre).IsRequired().HasMaxLength(150);
            task.Property(prop => prop.Descripcion).IsRequired(false);
            task.Property(prop => prop.PrioridadTarea);
            task.Property(prop => prop.FechaCreacion);
            task.Property(prop => prop.Apellido);
            task.HasData(tareasInit);
        });
   } 
}