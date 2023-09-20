using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Services;

public class TareaService : ITareaService
{
    private readonly TareasContext context;

    public TareaService(TareasContext dbcontext){
        context = dbcontext;
    }
    public IEnumerable<Tarea> Get(){
        return context.Tareas.Include(prop => prop.Categoria);
    }
    public async Task Update(Guid id, Tarea tarea){
        var TareaToUpdate = context.Tareas.Find(id);
        if(TareaToUpdate != null){
            TareaToUpdate.Nombre = tarea.Nombre;
            TareaToUpdate.Descripcion = tarea.Descripcion;
            await context.SaveChangesAsync();
        }
    }
    public async Task Save(Tarea tarea){
        await context.AddAsync(tarea);
        await context.SaveChangesAsync();
    }
    public async Task Delete(Guid id){
        var TareaToDelete = context.Tareas.Find(id);
        if(TareaToDelete != null){
            context.Tareas.Remove(TareaToDelete);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Update(Guid id, Tarea tarea);
    Task Save(Tarea tarea);
    Task Delete(Guid id);
}