using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.controllers;
[Route("[controller]")]
public class CategoriaController : ControllerBase
{

    protected readonly ICategoriaService categoriaService;
    public CategoriaController(ICategoriaService categoria){
        categoriaService = categoria;

    }
    [HttpGet]
    public IActionResult Get(){
        return Ok(categoriaService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody]Categoria categoria){
        categoriaService.Save(categoria);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Categoria categoria, Guid id){
        categoriaService.Update(id,categoria);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){
        categoriaService.Delete(id);
        return Ok();
    }
}