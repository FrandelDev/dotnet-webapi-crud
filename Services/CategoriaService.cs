using System.Security.Cryptography.X509Certificates;
using webapi.Models;

namespace webapi.Services;

public class CategoriaService : ICategoriaService
{
    private readonly TareasContext context;

    public CategoriaService(TareasContext dbContext){
        context = dbContext;
    }

    public IEnumerable<Categoria> Get(){
        return context.Categorias;
    }
    public async Task Update(Guid id, Categoria categoria){
        var CategoriaToUpdate = context.Categorias.Find(id);
        if(CategoriaToUpdate != null){
            CategoriaToUpdate.Nombre = categoria.Nombre;
            CategoriaToUpdate.Descripcion = categoria.Descripcion;
            await context.SaveChangesAsync();
        }
    }
    public async Task Save(Categoria categoria){
        await context.AddAsync(categoria);
        await context.SaveChangesAsync();
    }
    public async Task Delete(Guid id){
        var CategoriaToDelete = context.Categorias.Find(id);
        if(CategoriaToDelete != null){
            context.Categorias.Remove(CategoriaToDelete);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Update(Guid id, Categoria categoria);
    Task Save(Categoria categoria);
    Task Delete(Guid id);
}